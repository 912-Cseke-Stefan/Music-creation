using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Music.MusicDomain;
using System.Text.RegularExpressions;


namespace MusicCreator.Repository
{
    internal class TrackRepository : ITrackRepository
    {
        private SqlConnection conn;
        private SqlDataAdapter adapter;
        private DataSet dataset;
        private DataTable? table;
        private string query;
        private SqlCommandBuilder cmdBuild;
        private List<Track> tracks;

        private string getConnectionString()
        {
            return "Data Source=192.168.33.181,1235;" +
                "Integrated Security=true;Encrypt=False";
        }

        private string getConnectionString2()
        {
            return "Data Source=192.168.33.181,1235;Initial Catalog=MusicDB;" +
                "Integrated Security=true;Encrypt=False";
        }

        private Track generateTrackFromRowObject(DataRow row)
        {
            int id = (int)row["track_id"]; // ...
            string title = (string)row["title"];
            int type = (int)row["track_type"];
            byte[] audio = (byte[])row["audio"];
            return new Track(id, title, type, audio);
        }

        public TrackRepository()
        {
            // initializing connection
            conn = new SqlConnection(getConnectionString());
            query = "select * from TRACK";
            tracks = null;

            // creating database and tables if they do not exist already (from script)
            /*conn.Open();
            //FileInfo fileInfo = new FileInfo("D:\\Facultate\\sem4\\se\\Music-creation\\MauiApp1\\Repository\\dbcreate.sql");
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
            */

            // reconnecting to the database with another connection string
            // there might be a cleaner way; I didn't find it, good luck to you
            conn = new SqlConnection(getConnectionString2());

            // filling dataset
            adapter = new SqlDataAdapter(query, conn);
            dataset = new DataSet();
            adapter.Fill(dataset, "Track");
            table = dataset.Tables["Track"]; // this should be a shallow copy

            // building commands for the adapter
            cmdBuild = new SqlCommandBuilder(adapter);
            adapter.InsertCommand = cmdBuild.GetInsertCommand();
            adapter.DeleteCommand = cmdBuild.GetDeleteCommand();
        }

        public void add(Track elem)
        {
            DataRow row = table.NewRow();
            row["title"] = elem.getTitle();
            row["track_type"] = elem.getType();
            row["audio"] = elem.getSongData();
            table.Rows.Add(row);
            adapter.Update(dataset, "Track");
        }

        public void delete(Track elem)
        {
            foreach (DataRow row in table.Rows)
            {
                if ((int)row["track_id"] == elem.getId())
                    row.Delete();
            }
            dataset.AcceptChanges();
            adapter.Update(dataset, "Track");
        }

        public Track? search(int id)
        {
            var elems = from DataRow row in table.Rows
                        where (int)row["track_id"] == id // yeah, trust me bro
                        select row;

            if (elems == null)
                return null;

            DataRow elem = elems.FirstOrDefault();
            return generateTrackFromRowObject(elem);
        }

        public List<Track> getAll()
        {
            if (tracks != null)
                return tracks;
            var elems = from DataRow row in table.Rows
                        select generateTrackFromRowObject(row);
            tracks = elems.ToList();
            return tracks;
        }
    }
}