using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;

namespace ConsoleApplication1
{
    class Program
    {
        static readonly string server = "DAVIDS-PC";
        static readonly string DataBase = "CSCI3432Final";
        static readonly bool windowsAuth = true;
        static readonly string connectionString = string.Format("Server={0};Database={1};Trusted_Connection={2}",server,DataBase,windowsAuth);
        static Random rand = new Random();
        static void Main(string[] args)
        {

            //InsertItem(00001, "Padded Armor", 179);
            //var test = File.ReadAllLines("NameID.txt");
            //var bleh = test.Select(line => line.Split(',')).ToArray();

            ////1GenerateRandomMonsterLoot();
            //foreach (string[] line in bleh)
            //{
            //    string name = line[0];
            //    int ID = Convert.ToInt32(line[1]);
            //    InsertPlayerStats(ID,name);
            //}

            GenerateMonsterIDs();
            
            Console.ReadLine();

        }

        //public static void  Insertdata(string name, string tableName)
        //{
        //    SqlConnection db = new SqlConnection(connectionString);
        //    db.Open();
        //    string connection = string.Format("INSERT INTO {0} (name) VALUES (@name)", tableName);
        //    SqlCommand cmd = new SqlCommand(connection,db);
        //    cmd.Parameters.Add("@name", name);
        //    cmd.Parameters.AddWithValue("@name", name);
        //    cmd.ExecuteNonQuery();
        //}

        public static void InsertItem(int ItemId, string name, int gold)
        {
            SqlConnection db = new SqlConnection(connectionString);
            db.Open();
            string query = string.Format("INSERT INTO {0} (ItemID,ItemName,Gold) VALUES(@ItemID,@ItemName,@Gold)","Item");
            SqlCommand cmd = new SqlCommand(query,db);
            cmd.Parameters.AddWithValue("@ItemID", ItemId);
            cmd.Parameters.AddWithValue("@ItemName", name);
            cmd.Parameters.AddWithValue("@Gold", gold);

            cmd.ExecuteNonQuery();
            db.Close();
        }
        public static void InsertChestLoot(int ChestID, int ItemID, decimal dropRate, short Quantity)
        {
            SqlConnection db = new SqlConnection(connectionString);
            db.Open();
            string query =
                string.Format(
                    "INSERT INTO {0} (ChestID,ItemID,dropRate,Quantity) VALUES(@ChestID,@ItemID,@dropRate,@Quantity)",
                    "ChestLoot");
            SqlCommand cmd = new SqlCommand(query,db);
            cmd.Parameters.AddWithValue("@ChestID", ChestID);
            cmd.Parameters.AddWithValue("@ItemID", ItemID);
            cmd.Parameters.AddWithValue("@dropRate", dropRate);
            cmd.Parameters.AddWithValue("@Quantity", Quantity);
            cmd.ExecuteNonQuery();
            db.Close();
        }
        public static void InsertInventory(string PlayerName, int ItemID, short Quantity)
        {

            // Quantity can't be null but Item iD can. If Item ID is null... Quantity 0.
            SqlConnection db = new SqlConnection(connectionString);
            db.Open();
            string query =
                string.Format("INSERT INTO {0} (PlayerName,ItemID,Quantity) VALUES (@PlayerName,@ItemID,@Quantity)",
                    "Inventory");
            SqlCommand cmd = new SqlCommand(query,db);
            cmd.Parameters.AddWithValue("@PlayerName", PlayerName);
            cmd.Parameters.AddWithValue("@ItemID", ItemID);
            cmd.Parameters.AddWithValue("@Quantity", Quantity);
            cmd.ExecuteNonQuery();
            db.Close();
        }
        public static void InsertItemType(string Type, int ItemID)
        {
            // Item ID can be null but not Type.(Database Structure)
            SqlConnection db = new SqlConnection(connectionString);
            db.Open();
            string query = string.Format("INSERT INTO {0} (Type,ItemID) VALUES (@Type,@ItemID)", "ItemType");
            SqlCommand cmd = new SqlCommand(query,db);
            cmd.Parameters.AddWithValue("@Type", Type);
            cmd.Parameters.AddWithValue("@ItemID", ItemID);
            cmd.ExecuteNonQuery();
            db.Close();
        }
        public static void InsertMonster(string MonsterName, string Classification)
        {
            // Nothing can be null...
            SqlConnection db = new SqlConnection(connectionString);
            db.Open();
            string query = string.Format("INSERT INTO {0} (MonsterName,Classification) VALUES (@MonsterName,@Classification)", "Monster");
            SqlCommand cmd = new SqlCommand(query,db);
            cmd.Parameters.AddWithValue("@MonsterName", MonsterName);
            cmd.Parameters.AddWithValue("@Classification", Classification);
            cmd.ExecuteNonQuery();
            db.Close();
        }
        public static void InsertMonsterLoots(string MonsterName, int ItemID, decimal dropRate, short Quantity)
        {
            SqlConnection db = new SqlConnection(connectionString);
            db.Open();
            string query =
                string.Format(
                    "INSERT INTO {0} (MonsterName,ItemID,dropRate,Quantity) VALUES(@MonsterName,@ItemID,@dropRate,@Quantity)",
                    "MonsterLoots");
            SqlCommand cmd = new SqlCommand(query, db);
            cmd.Parameters.AddWithValue("@MonsterName", MonsterName);
            cmd.Parameters.AddWithValue("@ItemID", ItemID);
            cmd.Parameters.AddWithValue("@dropRate", dropRate);
            cmd.Parameters.AddWithValue("@Quantity", Quantity);
            cmd.ExecuteNonQuery();
            db.Close();
        }


        // fix this
        public static void InsertMonsterStats(decimal MonsterID, string MonsterName)
        {
            SqlConnection db = new SqlConnection(connectionString);
            db.Open();
            string query =
                string.Format(
                    "INSERT INTO {0} (MonsterID,MonsterName) VALUES(@MonsterID,@MonsterName)",
                    "MonsterStats");
            SqlCommand cmd = new SqlCommand(query, db);
            cmd.Parameters.AddWithValue("@MonsterID",MonsterID);
            cmd.Parameters.AddWithValue("@MonsterName", MonsterName);
            cmd.ExecuteNonQuery();
            db.Close();
        }
        public static void InsertPlayer(string PlayerName, string Race, string Gender, string Faction, string Class)
        {
            SqlConnection db = new SqlConnection(connectionString);
            db.Open();
            string query =
                string.Format(
                    "INSERT INTO {0} (PlayerName,Race,Gender,Faction,Class) VALUES(@PlayerName,@Race,@Gender,@Faction,@Class)",
                    "Player");
            SqlCommand cmd = new SqlCommand(query, db);
            cmd.Parameters.AddWithValue("@PlayerName", PlayerName);
            cmd.Parameters.AddWithValue("@ItemID", Race);
            cmd.Parameters.AddWithValue("@dropRate", Gender);
            cmd.Parameters.AddWithValue("@Quantity", Faction);
            cmd.Parameters.AddWithValue("@Class", Class);
            cmd.ExecuteNonQuery();
            db.Close();
        }

        public static void InsertPlayerStats(decimal ID, string PlayerName)
        {
            SqlConnection db = new SqlConnection(connectionString);
            db.Open();
            string query =
                string.Format(
                    "INSERT INTO {0} (ID,PlayerName) VALUES(@ID,@PlayerName)",
                    "PlayerStats");
            SqlCommand cmd = new SqlCommand(query, db);
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@PlayerName", PlayerName);
            cmd.ExecuteNonQuery();
            db.Close();
        }

        public static void InsertStats(decimal ID, decimal accuracy, decimal strength, decimal defense, decimal Health,
            decimal Level, decimal Magic)
        {
            SqlConnection db = new SqlConnection(connectionString);
            db.Open();
            string query =
                string.Format(
                    "INSERT INTO {0} (ID,Accuracy,Strength,Defense,Health,Level,Magic) VALUES(@ID,@Accuracy,@Strength,@Defense,@Health,@Level,@Magic)",
                    "Stats");
            SqlCommand cmd = new SqlCommand(query, db);
            cmd.Parameters.AddWithValue("@ID",ID);
            cmd.Parameters.AddWithValue("@Accuracy", accuracy);
            cmd.Parameters.AddWithValue("@Strength", strength);
            cmd.Parameters.AddWithValue("@Defense", defense);
            cmd.Parameters.AddWithValue("@Health", Health);
            cmd.Parameters.AddWithValue("@Level", Level);
            cmd.Parameters.AddWithValue("@Magic", Magic);
            cmd.ExecuteNonQuery();
            db.Close();
        }

        public static void GenerateRandomChestLoot()
        {
            for (int i = 1; i < 101; i++)
            {
                int id = i;
                int ItemID = rand.Next(11001, 11076);
                double DropRate = rand.NextDouble();
                double value = Math.Truncate(DropRate*100)/100;
                short Quantity = (short)rand.Next(0, 15);
                InsertChestLoot(id,ItemID,(decimal)value,Quantity);
            }
        }

        public static void GenerateRandomMonsterLoot()
        {
            var file = File.ReadAllLines("MonsterName.txt");
            var bleh = file.Select(line => line.Split(',')).ToArray();

            foreach (string[] monster in bleh)
            {
                string monsterName = monster[0];
                int ItemID = rand.Next(11001, 11076);
                double DropRate = rand.NextDouble();
                double value = Math.Truncate(DropRate * 100) / 100;
                short Quantity = (short) rand.Next(1, 12);
                InsertMonsterLoots(monsterName,ItemID,(decimal)value,Quantity);
            }
        }

        public static void GenerateMonsterStats()
        {
            var file = File.ReadAllLines("MonsterName.txt");
            Dictionary<string,int> name2Id = new Dictionary<string, int>();
            var bleh = file.Select(line => line.Split(',')).ToArray();
            for (int i = 1; i <= bleh.Length; i++)
            {
                string monsterName = bleh[i-1][0];
                int ID = i+9000;
                
                int accuracy = rand.Next(1, 1000);
                int strength = rand.Next(1, 1000);
                int defense = rand.Next(1, 1000);
                int health = rand.Next(1, 100000);
                int level = rand.Next(1, 256);
                int magic = rand.Next(1, 1000);
                InsertStats(ID,accuracy,strength,defense,health,level,magic);
            }
        }

        public static void GenerateMonsterIDs()
        {
            var file = File.ReadAllLines("MonsterName.txt");
            Dictionary<string, int> name2Id = new Dictionary<string, int>();
            int id = 9042;
            var bleh = file.Select(line => line.Split(',')).ToArray();
            foreach (string[] m in bleh)
            {
                string monsterName = m[0];
                name2Id.Add(monsterName,id);
                InsertMonsterStats(id,monsterName);
                id--;
            }
        }
    }
}
