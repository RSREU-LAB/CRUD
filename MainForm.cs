﻿using CRUD.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD
{
    public partial class MainForm : Form
    {
        private readonly Model _context;
        public MainForm()
        {
            InitializeComponent();
            _context = new Model();
            loadData();
        }


        private void loadData()
        {
            loadDataCulture();
            loadDataDistrict();
            loadDataProductivity();
        } 
    }
}
