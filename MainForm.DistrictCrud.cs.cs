using CRUD.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD
{
    public partial class MainForm
    {
        private void loadDataDistrict()
        {
            var data = _context.District
                .Select(d => new
                {
                    d.Id,
                    d.Name,
                    d.Region,
                    d.RegionHead
                })
                .ToList();

            dataGridViewDistrict.DataSource = data;
        }

        private void addButtonDistrict_Click(object sender, EventArgs e)
        {
            CreateAddFormDistrict();
        }

        private void editButtonDistrict_Click(object sender, EventArgs e)
        {
            CreateEditFormDistrict();
        }

        private void deleteButtonDistrict_Click(object sender, EventArgs e)
        {
            CreateDeleteFormDistrict();
        }

        private void CreateAddFormDistrict()
        {
            var form = new Form()
            {
                Width = 400,
                Height = 250,
                Text = "Добавить район",
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            };

            var lblName = new Label() { Text = "Название:", Left = 20, Top = 20, Width = 120 };
            var txtName = new TextBox() { Left = 150, Top = 18, Width = 200 };

            var lblRegion = new Label() { Text = "Регион:", Left = 20, Top = 60, Width = 120 };
            var txtRegion = new TextBox() { Left = 150, Top = 58, Width = 200 };

            var lblRegionHead = new Label() { Text = "Глава региона:", Left = 20, Top = 100, Width = 120 };
            var txtRegionHead = new TextBox() { Left = 150, Top = 98, Width = 200 };

            var okButton = new Button() { Text = "OK", DialogResult = DialogResult.OK, Left = 90, Width = 80, Top = 150 };
            var cancelButton = new Button() { Text = "Отмена", DialogResult = DialogResult.Cancel, Left = 190, Width = 80, Top = 150 };

            form.Controls.AddRange(new Control[] { lblName, txtName, lblRegion, txtRegion, lblRegionHead, txtRegionHead, okButton, cancelButton });

            form.AcceptButton = okButton;
            form.CancelButton = cancelButton;

            if (form.ShowDialog() == DialogResult.OK)
            {
                if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtRegion.Text))
                {
                    MessageBox.Show("Название и Регион не должны быть пустыми.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var newDistrict = new District
                {
                    Name = txtName.Text.Trim(),
                    Region = txtRegion.Text.Trim(),
                    RegionHead = txtRegionHead.Text.Trim()
                };

                _context.District.Add(newDistrict);
                _context.SaveChanges();
                loadDataDistrict();
            }
        }

        private void CreateEditFormDistrict()
        {
            var all = _context.District.ToList();
            if (all.Count == 0)
            {
                MessageBox.Show("Нет записей для редактирования.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var form = new Form()
            {
                Width = 450,
                Height = 280,
                Text = "Редактировать район",
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            };

            var lblSelect = new Label() { Text = "Выберите район:", Left = 20, Top = 20, Width = 130 };
            var comboBox = new ComboBox() { Left = 160, Top = 18, Width = 240, DropDownStyle = ComboBoxStyle.DropDownList };
            foreach (var d in all)
                comboBox.Items.Add(new ComboItem(d.Id, $"{d.Name} / {d.Region}"));
            comboBox.SelectedIndex = 0;

            var lblName = new Label() { Text = "Район:", Left = 20, Top = 60, Width = 130 };
            var txtName = new TextBox() { Left = 160, Top = 58, Width = 240 };

            var lblRegion = new Label() { Text = "Регион:", Left = 20, Top = 100, Width = 130 };
            var txtRegion = new TextBox() { Left = 160, Top = 98, Width = 240 };

            var lblRegionHead = new Label() { Text = "Глава региона:", Left = 20, Top = 140, Width = 130 };
            var txtRegionHead = new TextBox() { Left = 160, Top = 138, Width = 240 };

            void updateFields()
            {
                var selected = (ComboItem)comboBox.SelectedItem;
                var entity = _context.District.Find(selected.Id);
                if (entity != null)
                {
                    txtName.Text = entity.Name;
                    txtRegion.Text = entity.Region;
                    txtRegionHead.Text = entity.RegionHead;
                }
            }

            comboBox.SelectedIndexChanged += (s, e) => updateFields();
            updateFields();

            var okButton = new Button() { Text = "Сохранить", DialogResult = DialogResult.OK, Left = 130, Width = 100, Top = 190 };
            var cancelButton = new Button() { Text = "Отмена", DialogResult = DialogResult.Cancel, Left = 250, Width = 100, Top = 190 };

            form.Controls.AddRange(new Control[] { lblSelect, comboBox, lblName, txtName, lblRegion, txtRegion, lblRegionHead, txtRegionHead, okButton, cancelButton });

            form.AcceptButton = okButton;
            form.CancelButton = cancelButton;

            if (form.ShowDialog() == DialogResult.OK)
            {
                var selected = (ComboItem)comboBox.SelectedItem;
                var entity = _context.District.Find(selected.Id);
                if (entity != null)
                {
                    if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtRegion.Text))
                    {
                        MessageBox.Show("Название и Регион не должны быть пустыми.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    entity.Name = txtName.Text.Trim();
                    entity.Region = txtRegion.Text.Trim();
                    entity.RegionHead = txtRegionHead.Text.Trim();

                    _context.SaveChanges();
                    loadDataDistrict();
                }
                else
                {
                    MessageBox.Show("Запись не найдена.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CreateDeleteFormDistrict()
        {
            var all = _context.District.ToList();
            if (all.Count == 0)
            {
                MessageBox.Show("Нет записей для удаления.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var form = new Form()
            {
                Width = 400,
                Height = 160,
                Text = "Удалить район",
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            };

            var lblChoose = new Label() { Text = "Район:", Left = 20, Top = 20, Width = 100 };
            var comboBox = new ComboBox() { Left = 120, Top = 18, Width = 240, DropDownStyle = ComboBoxStyle.DropDownList };
            foreach (var d in all)
                comboBox.Items.Add(new ComboItem(d.Id, $"{d.Name} / {d.Region}"));
            comboBox.SelectedIndex = 0;

            var okButton = new Button() { Text = "Удалить", DialogResult = DialogResult.OK, Left = 120, Width = 100, Top = 60 };
            var cancelButton = new Button() { Text = "Отмена", DialogResult = DialogResult.Cancel, Left = 240, Width = 100, Top = 60 };

            form.Controls.AddRange(new Control[] { lblChoose, comboBox, okButton, cancelButton });

            form.AcceptButton = okButton;
            form.CancelButton = cancelButton;

            if (form.ShowDialog() == DialogResult.OK)
            {
                var result = MessageBox.Show(
                           "Вы уверены, что хотите удалить эту запись?",
                           "Подтверждение удаления",
                           MessageBoxButtons.YesNo,
                           MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    var selected = (ComboItem)comboBox.SelectedItem;
                    var entity = _context.District.Find(selected.Id);
                    if (entity != null)
                    {
                        if (entity.CultureProductivity != null && entity.CultureProductivity.Any())
                        {
                            MessageBox.Show("Невозможно удалить: к району привязаны записи продуктивности.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        _context.District.Remove(entity);
                        _context.SaveChanges();
                        loadDataDistrict();
                    }
                    else
                    {
                        MessageBox.Show("Запись не найдена.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
        }
    }
}
