using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Data.SqlClient;
using Music.MusicDomain;
using System.Text.RegularExpressions;
using AndroidX.Emoji2.Text.FlatBuffer;

namespace MauiApp1.Repository
{
    internal class MusigTagRepository : IMusicTagRepository
    {
        private SqlConnection conn;
        private SqlDataAdapter adapter;
        private DataSet dataset;
        private DataTable table;
        private string query;

        private string getConnectionString()
        {
            return "Data Source=10.152.0.159,1235;" +
                "Integrated Security=true;Encrypt=False";
        }

        private string getConnectionString2()
        {
            return "Data Source=10.152.0.159,1235;Initial Catalog=MusicDB;" +
                "Integrated Security=true;Encrypt=False";
        }

        private MusicTag generateMusicTagFromRowObject(DataRow row)
        {
            int id = (int)row["musictag_id"]; // I hope you will do a better job
            string title = (string)row["tag"];
            return new MusicTag(id, title);
        }

        public MusigTagRepository() 
        {
            // initializing connection
            conn = new SqlConnection(getConnectionString());
            query = "select * from MUSICTAG";

            // creating database and tables if they do not exist already (from script)
            conn.Open();
            FileInfo fileInfo = new FileInfo("D:\\Facultate\\sem4\\se\\Music-creation\\MauiApp1\\Repository\\dbcreate.sql");
            string script = fileInfo.OpenText().ReadToEnd();
            Regex regex = new Regex("^GO", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            string[] lines = regex.Split(script);
            SqlCommand cmd = conn.CreateCommand();
            cmd.Connection = conn;
            foreach (string line in lines)
            {
                cmd.CommandText = line;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }
            conn.Close();

            // reconnecting to the database with another connection string
            // there might be a cleaner way; I didn't find it, good luck to you
            conn = new SqlConnection(getConnectionString2());

            // filling dataset
            adapter = new SqlDataAdapter(query, conn);
            dataset = new DataSet();
            adapter.Fill(dataset, "MusicTag");
            table = dataset.Tables["MusicTag"]; // this should be a shallow copy
        }

        public void add(MusicTag elem)
        {
            DataRow row = table.NewRow();
            row["musictag_id"] = elem.getId();
            row["tag"] = elem.getTitle();
            table.Rows.Add(row);
            adapter.Update(dataset);
        }

        public MusicTag? search(int id)
        {
            var elems = from DataRow row in table.Rows
                        where (int)row["musictag_id"] == id // yeah, trust me bro
                        select row;

            if (elems == null)
                return null;

            DataRow elem = elems.FirstOrDefault();
            return generateMusicTagFromRowObject(elem); 
        }

        public MusicTag[] getAll()
        {
            var elems = from DataRow row in table.Rows
                        select generateMusicTagFromRowObject(row);
            return elems.ToArray();
        }
    }
}
