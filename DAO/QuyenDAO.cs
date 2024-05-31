using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class QuyenDAO
    {
        DataServices dataServices = new DataServices();
        DataTable dataTable;

        public QuyenDAO()
        {
        }

        public List<QuyenDTO> getAll()
        {
            List<QuyenDTO> list = new List<QuyenDTO>();
            string sql = "SELECT * FROM quyen";
            if (!dataServices.OpenDB()) return null;
            dataTable = dataServices.RunQuery(sql);
            QuyenDTO quyen;

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                quyen = new QuyenDTO();
                quyen.MaQuyen = (int)dataTable.Rows[i]["ma_quyen"];
                quyen.TenQuyen = dataTable.Rows[i]["ten_quyen"].ToString();
                list.Add(quyen);
            }

            return list;
        }

        public bool Insert(QuyenDTO quyen)
        {
            string sql = "SELECT * FROM quyen";
            dataTable = dataServices.RunQuery(sql);
            DataRow row = dataTable.NewRow();
            row["ma_quyen"] = quyen.MaQuyen;
            row["ten_quyen"] = quyen.TenQuyen;
            dataTable.Rows.Add(row);
            dataServices.Update(dataTable);
            return true;

        }

        public bool Delete(int maQuyen)
        {
            string sql = "SELECT * FROM chi_tiet_phan_quyen";
            dataTable = dataServices.RunQuery(sql);
            foreach(DataRow row in dataTable.Rows)
            {
                if (row["ma_quyen"].Equals(maQuyen))
                    row.Delete();
            }
            dataServices.Update(dataTable);

            sql = "SELECT * FROM quyen";
            dataTable = dataServices.RunQuery(sql);
            dataTable.PrimaryKey = new DataColumn[] { dataTable.Columns["ma_quyen"] };
            dataTable.Rows.Find(maQuyen).Delete();
            dataServices.Update(dataTable);
            return true;
        }

        public bool Update(QuyenDTO quyen)
        {
            string sql = "SELECT * FROM quyen";
            dataTable = dataServices.RunQuery(sql);
            dataTable.PrimaryKey = new DataColumn[] { dataTable.Columns["ma_quyen"] };
            DataRow row = dataTable.Rows.Find(quyen.MaQuyen);
            row["ma_quyen"] = quyen.MaQuyen;
            row["ten_quyen"] = quyen.TenQuyen;
            dataServices.Update(dataTable);
            return true;
        }

        public bool TrungMa(int maQuyen)
        {
            string sql = $"SELECT * FROM quyen WHERE ma_quyen = {maQuyen}";
            dataTable = dataServices.RunQuery(sql);
            if (dataTable.Rows.Count == 0) return false;
            return true;
        }

        public int NextID()
        {
            string sql = "SELECT MAX(ma_quyen) as 'max' FROM quyen";
            dataTable = dataServices.RunQuery(sql);
            int num = -1;
            if (!int.TryParse(dataTable.Rows[0]["max"].ToString(), out num)) return 1;
            int curId = (int)dataTable.Rows[0]["max"];
            return curId + 1;
        }
    }
}
