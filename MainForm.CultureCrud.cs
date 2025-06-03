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
        private void loadDataCulture()
        {
            var data = _context.Culture
                .Select(c => new
                {
                    c.Id,
                    c.Name,
                    c.Family
                })
                .ToList();

            dataGridViewCulture.DataSource = data;
        }

        private void addButtonCulture_Click(object sender, EventArgs e)
        {
            CreateAddFormCulture();
        }

        private void editButtonCulture_Click(object sender, EventArgs e)
        {
            CreateEditFormCulture();
        }

        private void deleteButtonCulture_Click(object sender, EventArgs e)
        {
            CreateDeleteFormCulture();
        }

        private void CreateAddFormCulture()
        {
            var form = new Form()
            {
                Width = 360,
                Height = 200,
                Text = "Добавить культуру",
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            };

            var lblName = new Label() { Text = "Название:", Left = 20, Top = 20, Width = 100 };
            var txtName = new TextBox() { Left = 120, Top = 18, Width = 200 };

            var lblFamily = new Label() { Text = "Семейство:", Left = 20, Top = 60, Width = 100 };
            var txtFamily = new TextBox() { Left = 120, Top = 58, Width = 200 };

            var okButton = new Button() { Text = "OK", DialogResult = DialogResult.OK, Left = 80, Width = 80, Top = 100 };
            var cancelButton = new Button() { Text = "Отмена", DialogResult = DialogResult.Cancel, Left = 180, Width = 80, Top = 100 };

            form.Controls.AddRange(new Control[] { lblName, txtName, lblFamily, txtFamily, okButton, cancelButton });

            form.AcceptButton = okButton;
            form.CancelButton = cancelButton;

            if (form.ShowDialog() == DialogResult.OK)
            {
                if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtFamily.Text))
                {
                    MessageBox.Show("Поля не должны быть пустыми.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var newCulture = new Culture
                {
                    Name = txtName.Text.Trim(),
                    Family = txtFamily.Text.Trim()
                };

                _context.Culture.Add(newCulture);
                _context.SaveChanges();
                loadDataCulture();
            }
        }

        private void CreateEditFormCulture()
        {
            var all = _context.Culture.ToList();
            if (all.Count == 0)
            {
                MessageBox.Show("Нет записей для редактирования.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var form = new Form()
            {
                Width = 400,
                Height = 240,
                Text = "Редактировать культуру",
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            };

            var lblSelect = new Label() { Text = "Выберите культуру:", Left = 20, Top = 20, Width = 140 };
            var comboBox = new ComboBox() { Left = 170, Top = 18, Width = 200, DropDownStyle = ComboBoxStyle.DropDownList };
            foreach (var c in all)
                comboBox.Items.Add(new ComboItem(c.Id, $"{c.Name} / {c.Family}"));
            comboBox.SelectedIndex = 0;

            var lblName = new Label() { Text = "Название:", Left = 20, Top = 60, Width = 100 };
            var txtName = new TextBox() { Left = 170, Top = 58, Width = 200 };

            var lblFamily = new Label() { Text = "Семейство:", Left = 20, Top = 100, Width = 100 };
            var txtFamily = new TextBox() { Left = 170, Top = 98, Width = 200 };

            void updateFields()
            {
                var selected = (ComboItem)comboBox.SelectedItem;
                var entity = _context.Culture.Find(selected.Id);
                if (entity != null)
                {
                    txtName.Text = entity.Name;
                    txtFamily.Text = entity.Family;
                }
            }

            comboBox.SelectedIndexChanged += (s, e) => updateFields();
            updateFields();

            var okButton = new Button() { Text = "Сохранить", DialogResult = DialogResult.OK, Left = 100, Width = 100, Top = 150 };
            var cancelButton = new Button() { Text = "Отмена", DialogResult = DialogResult.Cancel, Left = 220, Width = 100, Top = 150 };

            form.Controls.AddRange(new Control[] { lblSelect, comboBox, lblName, txtName, lblFamily, txtFamily, okButton, cancelButton });

            form.AcceptButton = okButton;
            form.CancelButton = cancelButton;

            if (form.ShowDialog() == DialogResult.OK)
            {
                var selected = (ComboItem)comboBox.SelectedItem;
                var entity = _context.Culture.Find(selected.Id);
                if (entity != null)
                {
                    entity.Name = txtName.Text.Trim();
                    entity.Family = txtFamily.Text.Trim();
                    _context.SaveChanges();
                    loadDataCulture();
                }
                else
                {
                    MessageBox.Show("Запись не найдена.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CreateDeleteFormCulture()
        {
            var all = _context.Culture.ToList();
            if (all.Count == 0)
            {
                MessageBox.Show("Нет записей для удаления.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var form = new Form()
            {
                Width = 400,
                Height = 160,
                Text = "Удалить культуру",
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            };

            var lblChoose = new Label() { Text = "Культура:", Left = 20, Top = 20, Width = 100 };
            var comboBox = new ComboBox() { Left = 120, Top = 18, Width = 240, DropDownStyle = ComboBoxStyle.DropDownList };
            foreach (var c in all)
                comboBox.Items.Add(new ComboItem(c.Id, $"{c.Name} / {c.Family}"));
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
                    var entity = _context.Culture.Find(selected.Id);
                    if (entity != null)
                    {
                        if (entity.CultureProductivity != null && entity.CultureProductivity.Any())
                        {
                            MessageBox.Show("Невозможно удалить: к культуре привязаны записи продуктивности.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        _context.Culture.Remove(entity);
                        _context.SaveChanges();
                        loadDataCulture();
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
