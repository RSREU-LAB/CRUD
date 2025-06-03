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
        private void loadDataProductivity()
        {
            var data = _context.CultureProductivity
                        .Select(p => new
                        {
                            p.DistrictId,
                            p.CultureId,
                            p.Year,
                            Culture = p.Culture.Name,
                            District = p.District.Name,
                            p.Productivity
                        })
                        .ToList();

            dataGridViewProductivity.DataSource = data;
        }

        private void deleteButtonProductivity_Click(object sender, EventArgs e)
        {
            CreateDeleteFormProductivity();
        }

        private void addButtonProductivity_Click(object sender, EventArgs e)
        {
            CreateAddFormProductivity();
        }

        private void editButtonProductivity_Click(object sender, EventArgs e)
        {
            CreateEditFormProductivity();
        }



        private void CreateDeleteFormProductivity()
        {
            var all = _context.CultureProductivity
                              .Select(p => new
                              {
                                  p.DistrictId,
                                  p.CultureId,
                                  p.Year,
                                  DistrictName = p.District.Name,
                                  CultureName = p.Culture.Name
                              })
                              .ToList();

            if (all.Count == 0)
            {
                MessageBox.Show("Нет записей для удаления.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var form = new Form()
            {
                Width = 400,
                Height = 150,
                Text = "Удалить запись",
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            };

            var lblChoose = new Label()
            {
                Text = "Запись:",
                Left = 20,
                Top = 20,
                Width = 100
            };
            form.Controls.Add(lblChoose);

            var comboItems = new ComboBox()
            {
                Left = 120,
                Top = 18,
                Width = 240,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            form.Controls.Add(comboItems);

            foreach (var ent in all)
            {
                string display = $"{ent.DistrictName} / {ent.CultureName} / {ent.Year}";
                comboItems.Items.Add(new ComboItemKey(ent.DistrictId, ent.CultureId, ent.Year, display));
            }
            comboItems.SelectedIndex = 0;

            var okButton = new Button()
            {
                Text = "Удалить",
                DialogResult = DialogResult.OK,
                Left = 120,
                Width = 100,
                Top = 70
            };
            form.Controls.Add(okButton);

            var cancelButton = new Button()
            {
                Text = "Отмена",
                DialogResult = DialogResult.Cancel,
                Left = 240,
                Width = 100,
                Top = 70
            };
            form.Controls.Add(cancelButton);

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
                    var selected = (ComboItemKey)comboItems.SelectedItem;
                    var entity = _context.CultureProductivity.Find(selected.Id1, selected.Id2, selected.Year);
                    if (entity != null)
                    {
                        _context.CultureProductivity.Remove(entity);
                        _context.SaveChanges();
                        loadDataProductivity();
                    }
                    else
                    {
                        MessageBox.Show("Не удалось найти запись.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
        }

        private void CreateAddFormProductivity()
        {
            var form = new Form()
            {
                Width = 360,
                Height = 260,
                Text = "Добавить продуктивность",
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            };

            var lblDistrict = new Label()
            {
                Text = "Район:",
                Left = 20,
                Top = 20,
                Width = 100
            };
            form.Controls.Add(lblDistrict);

            var comboDistrict = new ComboBox()
            {
                Left = 120,
                Top = 18,
                Width = 200,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            form.Controls.Add(comboDistrict);

            var lblCulture = new Label()
            {
                Text = "Культура:",
                Left = 20,
                Top = 60,
                Width = 100
            };
            form.Controls.Add(lblCulture);

            var comboCulture = new ComboBox()
            {
                Left = 120,
                Top = 58,
                Width = 200,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            form.Controls.Add(comboCulture);

            var lblYear = new Label()
            {
                Text = "Год:",
                Left = 20,
                Top = 100,
                Width = 100
            };
            form.Controls.Add(lblYear);

            var numericYear = new NumericUpDown()
            {
                Left = 120,
                Top = 98,
                Width = 200,
                Minimum = 1900,
                Maximum = 2100,
                Value = DateTime.Now.Year
            };
            form.Controls.Add(numericYear);

            var lblProd = new Label()
            {
                Text = "Продуктивность:",
                Left = 20,
                Top = 140,
                Width = 100
            };
            form.Controls.Add(lblProd);

            var numericProd = new NumericUpDown()
            {
                Left = 120,
                Top = 138,
                Width = 200,
                Minimum = 0,
                Maximum = 1000000,
                DecimalPlaces = 0
            };
            form.Controls.Add(numericProd);

            var okButton = new Button()
            {
                Text = "OK",
                DialogResult = DialogResult.OK,
                Left = 80,
                Width = 80,
                Top = 180
            };
            form.Controls.Add(okButton);

            var cancelButton = new Button()
            {
                Text = "Отмена",
                DialogResult = DialogResult.Cancel,
                Left = 180,
                Width = 80,
                Top = 180
            };
            form.Controls.Add(cancelButton);

            form.AcceptButton = okButton;
            form.CancelButton = cancelButton;

            var districts = _context.District.OrderBy(d => d.Name).ToList();
            foreach (var d in districts)
                comboDistrict.Items.Add(new ComboItem(d.Id, d.Name));

            var cultures = _context.Culture.OrderBy(c => c.Name).ToList();
            foreach (var c in cultures)
                comboCulture.Items.Add(new ComboItem(c.Id, c.Name));

            if (comboDistrict.Items.Count > 0)
                comboDistrict.SelectedIndex = 0;
            if (comboCulture.Items.Count > 0)
                comboCulture.SelectedIndex = 0;

            if (form.ShowDialog() == DialogResult.OK)
            {
                if (comboDistrict.SelectedItem == null || comboCulture.SelectedItem == null)
                {
                    MessageBox.Show("Нужно выбрать и район, и культуру.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var selDistrict = (ComboItem)comboDistrict.SelectedItem;
                var selCulture = (ComboItem)comboCulture.SelectedItem;
                short year = Convert.ToInt16(numericYear.Value);
                int prodValue = Convert.ToInt32(numericProd.Value);

                var exists = _context.CultureProductivity.Find(selDistrict.Id, selCulture.Id, year);
                if (exists != null)
                {
                    MessageBox.Show("Запись за этот год уже существует.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var newEntity = new CultureProductivity
                {
                    DistrictId = selDistrict.Id,
                    CultureId = selCulture.Id,
                    Year = year,
                    Productivity = prodValue
                };
                _context.CultureProductivity.Add(newEntity);
                _context.SaveChanges();
                loadDataProductivity();
            }
        }

        private class ComboItem
        {
            public int Id { get; }
            public string Display { get; }

            public ComboItem(int id, string display)
            {
                Id = id;
                Display = display;
            }

            public override string ToString() => Display;
        }

        private void CreateEditFormProductivity()
        {
            var all = _context.CultureProductivity
                              .Select(p => new
                              {
                                  p.DistrictId,
                                  p.CultureId,
                                  p.Year,
                                  DistrictName = p.District.Name,
                                  CultureName = p.Culture.Name,
                                  p.Productivity
                              })
                              .ToList();

            if (all.Count == 0)
            {
                MessageBox.Show("Нет записей для редактирования.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var form = new Form()
            {
                Width = 400,
                Height = 250,
                Text = "Редактировать продуктивность",
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            };

            var lblSelect = new Label()
            {
                Text = "Выберите запись:",
                Left = 20,
                Top = 20,
                Width = 120
            };
            form.Controls.Add(lblSelect);

            var comboBox = new ComboBox()
            {
                Left = 150,
                Top = 18,
                Width = 220,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            form.Controls.Add(comboBox);

            foreach (var item in all)
            {
                string display = $"{item.DistrictName} / {item.CultureName} / {item.Year}";
                comboBox.Items.Add(new ComboItemKey(item.DistrictId, item.CultureId, item.Year, display));
            }

            comboBox.SelectedIndex = 0;

            var lblProd = new Label()
            {
                Text = "Продуктивность:",
                Left = 20,
                Top = 70,
                Width = 120
            };
            form.Controls.Add(lblProd);

            var numericProd = new NumericUpDown()
            {
                Left = 150,
                Top = 68,
                Width = 220,
                Minimum = 0,
                Maximum = 1000000,
                DecimalPlaces = 0
            };
            form.Controls.Add(numericProd);

            // Обновить значение продуктивности при выборе
            comboBox.SelectedIndexChanged += (s, e) =>
            {
                var selected = (ComboItemKey)comboBox.SelectedItem;
                var entity = _context.CultureProductivity.Find(selected.Id1, selected.Id2, selected.Year);
                numericProd.Value = entity?.Productivity ?? 0;
            };

            // Установить значение при запуске
            {
                var selected = (ComboItemKey)comboBox.SelectedItem;
                var entity = _context.CultureProductivity.Find(selected.Id1, selected.Id2, selected.Year);
                numericProd.Value = entity?.Productivity ?? 0;
            }

            var okButton = new Button()
            {
                Text = "Сохранить",
                DialogResult = DialogResult.OK,
                Left = 100,
                Width = 100,
                Top = 130
            };
            form.Controls.Add(okButton);

            var cancelButton = new Button()
            {
                Text = "Отмена",
                DialogResult = DialogResult.Cancel,
                Left = 220,
                Width = 100,
                Top = 130
            };
            form.Controls.Add(cancelButton);

            form.AcceptButton = okButton;
            form.CancelButton = cancelButton;

            if (form.ShowDialog() == DialogResult.OK)
            {
                var selected = (ComboItemKey)comboBox.SelectedItem;
                var entity = _context.CultureProductivity.Find(selected.Id1, selected.Id2, selected.Year);
                if (entity != null)
                {
                    entity.Productivity = Convert.ToInt32(numericProd.Value);
                    _context.SaveChanges();
                    loadDataProductivity();
                }
                else
                {
                    MessageBox.Show("Запись не найдена.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private class ComboItemKey
        {
            public int Id1 { get; }
            public int Id2 { get; }
            public short Year { get; }
            public string Display { get; }

            public ComboItemKey(int id1, int id2, short year, string display)
            {
                Id1 = id1;
                Id2 = id2;
                Year = year;
                Display = display;
            }

            public override string ToString() => Display;
        }
    }
}
