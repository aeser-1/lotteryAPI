using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lotteryAPI;
using MySql.Data.MySqlClient;

namespace lotteryAPI
{
    public class LotterytabContext
    {
        public string ConnectionString { get; set; }

        public LotterytabContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public List<Ticket> GetAll()
        {
            List<Ticket> list = new List<Ticket>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from lottery_tab", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Ticket()
                        {
                            month = Convert.ToInt32(reader["month"]),
                            year = Convert.ToInt32(reader["year"]),
                            n1 = Convert.ToInt32(reader["n1"]),
                            n2 = Convert.ToInt32(reader["n2"]),
                            n3 = Convert.ToInt32(reader["n3"]),
                            n4 = Convert.ToInt32(reader["n4"]),
                            n5 = Convert.ToInt32(reader["n5"]),
                            n6 = Convert.ToInt32(reader["n6"]),
                        });
                    }
                }
            }
            return list;
        }

        public List<Ticket> Get(int month,int year)
        {
            List<Ticket> list = new List<Ticket>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from lottery_tab where month="+month+" and year="+year+" ", conn);
                using MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new Ticket()
                    {
                        month = Convert.ToInt32(reader["month"]),
                        year = Convert.ToInt32(reader["year"]),
                        n1 = Convert.ToInt32(reader["n1"]),
                        n2 = Convert.ToInt32(reader["n2"]),
                        n3 = Convert.ToInt32(reader["n3"]),
                        n4 = Convert.ToInt32(reader["n4"]),
                        n5 = Convert.ToInt32(reader["n5"]),
                        n6 = Convert.ToInt32(reader["n6"]),
                    });
                }
            }
            return list;
        }

        public List<Ticket> Get(int n1, int n2, int n3, int n4, int n5, int n6)
        {
            List<Ticket> list = new List<Ticket>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from lottery_tab where n1="+n1+" and n2="+n2+" and n3="+n3+ " and n4="+n4+" and n5="+n5+" and n6="+n6+" ", conn);
                using MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new Ticket()
                    {
                        month = Convert.ToInt32(reader["month"]),
                        year = Convert.ToInt32(reader["year"]),
                        n1 = Convert.ToInt32(reader["n1"]),
                        n2 = Convert.ToInt32(reader["n2"]),
                        n3 = Convert.ToInt32(reader["n3"]),
                        n4 = Convert.ToInt32(reader["n4"]),
                        n5 = Convert.ToInt32(reader["n5"]),
                        n6 = Convert.ToInt32(reader["n6"]),
                    });
                }
            }
            return list;
        }

    }
}

