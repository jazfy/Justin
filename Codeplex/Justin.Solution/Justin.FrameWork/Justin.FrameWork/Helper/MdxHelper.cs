﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Microsoft.AnalysisServices.AdomdClient;

namespace Justin.FrameWork.Helper
{
    public class MdxHelper
    {
        public static string ConnectionString = "Provider=MSOLAP;Initial Catalog=analysis;Data Source=TPLAB-432.grandsoft.com.cn;Mode=Read";
        //"Data Source=zhangxh-a;Catalog=analysis;ConnectTo=9.0;Integrated Security=SSPI";
        //"Provider=MSOLAP;Initial Catalog=GBMS ;Data Source=D:\CompanyCode\CN.cub_Oct1.cub;Mode=Read"

        public static int ExecuteNonQuery(AdomdConnection conn, string CommandText)
        {
            try
            {
                // Create a new Adomd command
                AdomdCommand command = new AdomdCommand();

                //Prepare the command
                SetCommand(conn, command, CommandText);

                //Execute the command
                int val = command.ExecuteNonQuery();

                command.Parameters.Clear();

                return val;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static object ExecuteScalar(AdomdConnection conn, string CommandText)
        {

            try
            {
                // Create a new Adomd command
                AdomdCommand command = new AdomdCommand();

                //Prepare the command
                SetCommand(conn, command, CommandText);

                //Execute the command
                object obj = command.ExecuteScalar();
                //var aa = cst.Axes[0].Set.Tuples[0].Members[0].GetChildren();
                command.Parameters.Clear();
                //var bb = cst.Axes[0].Set.Tuples[0].Members[0].GetChildren();
                return obj;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static CellSet ExecuteCellSet(AdomdConnection conn, string CommandText)
        {

            try
            {
                // Create a new Adomd command
                AdomdCommand command = new AdomdCommand();

                //Prepare the command
                SetCommand(conn, command, CommandText);

                //Execute the command
                CellSet cst = command.ExecuteCellSet();
                //var aa = cst.Axes[0].Set.Tuples[0].Members[0].GetChildren();
                command.Parameters.Clear();
                //var bb = cst.Axes[0].Set.Tuples[0].Members[0].GetChildren();
                return cst;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static AdomdDataReader ExecuteReader(AdomdConnection conn, string CommandText)
        {

            try
            {
                // Create a new Adomd command
                AdomdCommand command = new AdomdCommand();

                //Prepare the command
                SetCommand(conn, command, CommandText);

                //Execute the command
                AdomdDataReader rd = command.ExecuteReader();
                //var aa = cst.Axes[0].Set.Tuples[0].Members[0].GetChildren();
                command.Parameters.Clear();
                //var bb = cst.Axes[0].Set.Tuples[0].Members[0].GetChildren();
                return rd;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static AdomdConnection GetConnection(string ConnectionString)
        {
            return new AdomdConnection(ConnectionString);
        }
        private static void SetCommand(AdomdConnection connection, AdomdCommand command, string CommandText)
        {
            //Open the connection if required
            if (connection.State != ConnectionState.Open)
                connection.Open();
            //Set up the command
            command.Connection = connection;
            command.CommandText = CommandText;
            command.CommandType = CommandType.Text;
        }
    }
}
