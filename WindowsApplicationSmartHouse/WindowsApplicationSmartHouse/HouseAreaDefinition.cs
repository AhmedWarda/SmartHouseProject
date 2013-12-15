using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsApplicationSmartHouse.HouseAreaService;

namespace WindowsApplicationSmartHouse
{
    public partial class HouseAreaDefinition : Form
    {
        public HouseAreaDefinition()
        {
            InitializeComponent();
        }

        ArrayList _houseAreaList = new ArrayList();
        public void ShowAllHouseAreas()
        {
            dataGridViewHouseArea.Rows.Clear();

            HouseAreaService.HouseAreaClient _has=new HouseAreaClient();

            string[] _houseAreasID = _has.GetAllHouseAreasID();


            for (int i = 0; i < _houseAreasID.Length; i++)
            {
                string[] _houseAreasData = _has.GetHouseAreaData(_houseAreasID[i]);

                dataGridViewHouseArea.Rows.Add();
                dataGridViewHouseArea[_colAreaAlreadyInDB.Name, i].Value = "1";
                dataGridViewHouseArea[_colAreaID.Name, i].Value = _houseAreasData[0];
                dataGridViewHouseArea[_colAreaName.Name, i].Value = _houseAreasData[1];
                dataGridViewHouseArea[_colAreaStatus.Name, i].Value = _houseAreasData[2];
            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            ShowAllHouseAreas();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            dataGridViewHouseArea.Rows.Add();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewHouseArea.Rows[dataGridViewHouseArea.CurrentRow.Index].Cells[_colAreaID.Name].Value != null)
            {

                _houseAreaList.Add(
                    dataGridViewHouseArea.Rows[dataGridViewHouseArea.CurrentRow.Index].Cells[_colAreaID.Name].Value.
                        ToString()
                        .Trim());
            }

            dataGridViewHouseArea.Rows.RemoveAt(dataGridViewHouseArea.CurrentRow.Index);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            HouseAreaService.HouseAreaClient _has=new HouseAreaClient();

            for (int i = 0; i < dataGridViewHouseArea.Rows.Count; i++)
            {
                if (dataGridViewHouseArea.Rows[i].Cells[_colAreaAlreadyInDB.Name].Value != null)
                {
                    //Update
                    string[] _houseAreaData = new string[3];
                    _houseAreaData[0] = dataGridViewHouseArea.Rows[i].Cells[_colAreaID.Name].Value.ToString().Trim();
                    _houseAreaData[1] = dataGridViewHouseArea.Rows[i].Cells[_colAreaName.Name].Value.ToString().Trim();
                    _houseAreaData[2] = dataGridViewHouseArea.Rows[i].Cells[_colAreaStatus.Name].Value.ToString().Trim();

                    _has.UpdateHouseArea(_houseAreaData);

                }

                else
                {
                    //Add New
                    string[] _houseAreaData = new string[3];
                    _houseAreaData[0] = dataGridViewHouseArea.Rows[i].Cells[_colAreaID.Name].Value.ToString().Trim();
                    _houseAreaData[1] = dataGridViewHouseArea.Rows[i].Cells[_colAreaName.Name].Value.ToString().Trim();
                    _houseAreaData[2] = dataGridViewHouseArea.Rows[i].Cells[_colAreaStatus.Name].Value.ToString().Trim();

                    _has.AddHouseArea(_houseAreaData);

                }
            }

            //Delete

            for (int i = 0; i < _houseAreaList.Count; i++)
            {
                _has.DeleteHouseArea(_houseAreaList[i].ToString().Trim());
            }

            MessageBox.Show("Data is saved successfully");

            ShowAllHouseAreas();
        }

        private void btnDevicesAssignment_Click(object sender, EventArgs e)
        {
            AssignmentHouseAreaToDevice _ahatd=new AssignmentHouseAreaToDevice();
            _ahatd.ShowDialog();
        }

        private void HouseAreaDefinition_Load(object sender, EventArgs e)
        {

        }
    }
}
