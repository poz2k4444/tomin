using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace MigraWinPred
{
    public class DataTableCreateInCode : System.Windows.Forms.Form
    {
        List<string> cveAnterior = new List<string>();
        string pathString = @"C:\LogsTomin";
        string fileName = "Errores.txt";
        private System.Windows.Forms.DataGrid dataGrid1;
        private System.ComponentModel.Container components = null;

        public DataTableCreateInCode()
        {
            InitializeComponent();

            //dcConstructorsTest();
            CreateCustTable();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGrid1
            // 
            this.dataGrid1.DataMember = "";
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(8, 8);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(600, 264);
            this.dataGrid1.TabIndex = 0;
            this.dataGrid1.Navigate += new System.Windows.Forms.NavigateEventHandler(this.dataGrid1_Navigate);
            // 
            // DataTableCreateInCode
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(616, 285);
            this.Controls.Add(this.dataGrid1);
            this.Name = "DataTableCreateInCode";
            this.Text = "DataTableCreateInCode";
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);


        }

        [STAThread]
        static void Main()
        {
            Application.Run(new DataTableCreateInCode());
        }

        // Create a DataTable de Contribuyentes
        private void CreateCustTable()
        {
            Stopwatch regularSW = new Stopwatch();
            regularSW.Start();
            // Create a new DataTable
            /*DataTable custTable = new DataTable("Contribuyentes");

            // Create ID Column
            DataColumn IdCol = new DataColumn();
            IdCol.ColumnName = "ID";
            IdCol.DataType = Type.GetType("System.Int32");
            IdCol.ReadOnly = true;
            IdCol.AllowDBNull = false;
            IdCol.Unique = true;
            IdCol.AutoIncrement = true;
            IdCol.AutoIncrementSeed = 1;
            IdCol.AutoIncrementStep = 1;
            custTable.Columns.Add(IdCol);

            // Create Cuenta Column
            DataColumn cuentaCol = new DataColumn();
            cuentaCol.ColumnName = "Cuenta";
            cuentaCol.DataType = Type.GetType("System.String");
            custTable.Columns.Add(cuentaCol);

            // Create Nombre Column
            DataColumn nameCol = new DataColumn();
            nameCol.ColumnName = "Nombre";
            nameCol.DataType = Type.GetType("System.String");
            custTable.Columns.Add(nameCol);

            // Create Paterno Column
            DataColumn appCol = new DataColumn();
            appCol.ColumnName = "Paterno";
            appCol.DataType = Type.GetType("System.String");
            custTable.Columns.Add(appCol);

            // Create Materno Column
            DataColumn apmCol = new DataColumn();
            apmCol.ColumnName = "Materno";
            apmCol.DataType = Type.GetType("System.String");
            custTable.Columns.Add(apmCol);

            //// Create Calle Column
            DataColumn calleCol = new DataColumn();
            calleCol.ColumnName = "Calle";
            calleCol.DataType = Type.GetType("System.String");
            custTable.Columns.Add(calleCol);

            //// Create NumInt Column
            DataColumn NumExtCol = new DataColumn();
            NumExtCol.ColumnName = "NumeroExt";
            NumExtCol.DataType = Type.GetType("System.String");
            custTable.Columns.Add(NumExtCol);

            //// Create NumExt Column
            DataColumn tipEnt = new DataColumn();
            tipEnt.ColumnName = "tipEnt";
            tipEnt.DataType = Type.GetType("System.String");
            custTable.Columns.Add(tipEnt);

            //// Create Colonia Column
            //DataColumn ColCol = new DataColumn();
            //ColCol.ColumnName = "Colonia";
            //ColCol.DataType = Type.GetType("System.String");
            //custTable.Columns.Add(ColCol);

            //// Create Comunidad Column
            //DataColumn ComCol = new DataColumn();
            //ComCol.ColumnName = "Comunidad";
            //ComCol.DataType = Type.GetType("System.String");
            //custTable.Columns.Add(ComCol);

            //// Create Ciudad Column
            //DataColumn CdCol = new DataColumn();
            //CdCol.ColumnName = "Ciudad";
            //CdCol.DataType = Type.GetType("System.String");
            //custTable.Columns.Add(CdCol);

            //// Create Estado Column
            //DataColumn EdoCol = new DataColumn();
            //EdoCol.ColumnName = "Estado";
            //EdoCol.DataType = Type.GetType("System.String");
            //custTable.Columns.Add(EdoCol);

            // Make the ID column the primary key column.
            DataColumn[] PrimaryKeyColumns = new DataColumn[1];
            PrimaryKeyColumns[0] = custTable.Columns["ID"];
            custTable.PrimaryKey = PrimaryKeyColumns;*/

            OdbcConnection connDBF = new OdbcConnection();
            connDBF.ConnectionString = ("Driver={Microsoft dBASE Driver (*.dbf)};DriverID=21;Dbq=C:\\Users\\user\\Desktop\\20121218\\DATOS\\;");

            //dummy variable
            string numExt = "";

            pathString = System.IO.Path.Combine(pathString, fileName);
            if (!System.IO.File.Exists(pathString))
            {
                System.IO.File.Create(pathString);
            }
            else
            {
                System.IO.File.AppendAllText(pathString, "algo" + Environment.NewLine);
                MessageBox.Show("Archivo Existe");
            }


            //SqlConnection mySqlConnection = new SqlConnection("user id=sa;" +
            //                         "password=4dm1nz4c.;server=10.32.193.111;" +
            //                      "database=Tomin; " +
            //                   "connection timeout=30");


            SqlConnection mySqlConnection = new SqlConnection();
            mySqlConnection.ConnectionString = "Data Source=(local);" +
                                        "Initial Catalog=Tomin;" +
                                        "Integrated Security=SSPI";
            // SE ABRE LA CONEXION A LA BASE DE DATOS DE SQL
            try
            {
                mySqlConnection.Open();
                MessageBox.Show("Success123");
                System.IO.File.AppendAllText(pathString, "Entra ala base" + Environment.NewLine);
            }
            catch (Exception e)
            {

                MessageBox.Show("Nop " + e.ToString());
            }



            int counter = 1;
            connDBF.Open();
            
            try
            {
                // Open Drawing Database
                

                // Query para insertar entidades
                string jobData = "SELECT * FROM CONTRIB.DBF";

                OdbcCommand cmd = new OdbcCommand();
                cmd.CommandText = (jobData);

                OdbcDataAdapter dbAdapter = new OdbcDataAdapter(jobData, connDBF);

                DataSet dtSet = new DataSet();
                dbAdapter.Fill(dtSet);

                DataTable dbTable = dtSet.Tables[0];

                foreach (DataRow dbRow in dbTable.Rows)
                {
                    String NombreCompleto = dbRow["NOMBRE"].ToString();
                    NombreCompleto = NombreCompleto.Replace("¥", "Ñ");
                    NombreCompleto = NombreCompleto.Replace("'", "\''");
                    string ultimoasignado = null;
                    //bool repe = checaDuplicados(NombreCompleto);
                    //if (!checaDuplicados(NombreCompleto, mySqlConnection))
                      //  MessageBox.Show(checaDuplicados(NombreCompleto, mySqlConnection).ToString());
                    //MessageBox.Show(NombreCompleto);
                    String[] separados;
                    separados = NombreCompleto.Split(" ".ToCharArray());

                    String[] domicilioSeparado;
                    String domicilio = dbRow["DOMICILIO"].ToString();
                    //domicilio = domicilio.Replace(@"#", @" ");
                    domicilioSeparado = domicilio.Split(" ".ToArray());
                    int tipoEntidad = 2;

                    string paterno = null, materno = null, nombre = null;

                    string[] palabras = new string[] { "DE", "LA", "DEL", "Y"};
                    string[] PerMorales = new string[] { "C.V.", "S.A.", "TRIBUTARIA", "INSTITUTO", "PRESIDENCIA" };

                    Boolean empresa = false;


                    if (separados.Length > 2)
                    {
                        empresa = false;
                        foreach (string empre in separados) // valida si es empresa
                        {
                            int entra = Array.IndexOf(PerMorales, empre);
                            if (entra != -1)
                            {
                                empresa = true;
                            }
                        }

                        if (empresa)
                        {
                            nombre = NombreCompleto;
                            tipoEntidad = 4;
                        }
                        else 
                        {
                            foreach (string word in separados)
                            {
                                int entra = Array.IndexOf(palabras, word);

                                if (entra != -1)
                                {
                                    if (paterno == null)
                                    {
                                        paterno = word;
                                        ultimoasignado = "paterno";
                                    }
                                    else if (ultimoasignado == "paterno")
                                    {
                                        paterno = paterno + " " + word;
                                        ultimoasignado = "paterno";
                                    }
                                    else if (materno == null)
                                    {
                                        if (word == "Y")
                                        {
                                            paterno = paterno + " " + word;
                                            ultimoasignado = "paterno";
                                        }
                                        else
                                        {
                                            materno = word;
                                            ultimoasignado = "materno";
                                        }
                                    }
                                    else if (ultimoasignado == "materno")
                                    {
                                        materno = materno + " " + word;
                                        ultimoasignado = "materno";
                                    }
                                    else if (nombre == null)
                                    {
                                        materno = materno + " " + word;
                                        ultimoasignado = "materno";
                                        tipoEntidad = 3;
                                    }
                                }
                                else
                                {
                                    if (paterno == null)
                                    {
                                        paterno = word;
                                    }
                                    else if (ultimoasignado == "paterno")
                                    {
                                        paterno = paterno + " " + word;
                                        ultimoasignado = null;
                                    }
                                    else if (materno == null)
                                    {
                                        materno = word;
                                    }
                                    else if (ultimoasignado == "materno")
                                    {
                                        materno = materno + " " + word;
                                        ultimoasignado = null;
                                    }
                                    else if (nombre == null)
                                    {
                                        nombre = word;
                                    }
                                    else
                                    {
                                        nombre = nombre + " " + word;
                                        tipoEntidad = 3;
                                    }
                                }
                                tipoEntidad = 3;
                            } // Termina foreach (string word in separados)

                            if (nombre == null)
                            {
                                nombre = materno;
                                materno = null;
                                tipoEntidad = 3;
                            }
                        } // termina if empresa 
                    }
                    else if (separados.Length == 2)
                    {
                        paterno = separados[0];
                        nombre = separados[1];
                        tipoEntidad = 3;
                    }
                    else 
                    {
                        nombre = NombreCompleto;
                        tipoEntidad = 3;
                    }

                    if (dbRow["CUENTA"] != null )
                    {
                        if (domicilioSeparado.Length > 1)
                        {
                            if (Regex.IsMatch(domicilioSeparado.Last(), @"\d"))
                            {
                                String domicilioSinNum = "";
                                for (int z = 0; z < domicilioSeparado.Length-1; z++)
                                {
                                    domicilioSinNum += " " + domicilioSeparado[z];
                                }
                                //custTable.Rows.Add(counter, dbRow["CUENTA"].ToString().Trim(), nombre, paterno, materno, domicilioSinNum, domicilioSeparado.Last(), tipoEntidad);
                                numExt = domicilioSeparado.Last();
                            }
                            else
                            {
                                //custTable.Rows.Add(counter, dbRow["CUENTA"].ToString().Trim(), nombre, paterno, materno, domicilio, null, tipoEntidad);
                                numExt = string.Empty;
                            }
                            
                        }
                        else {

                            
                            domicilioSeparado = domicilio.Split('#');
                            if (Regex.IsMatch(domicilioSeparado.Last(), @"\d"))
                            {
                                String domicilioSinNum = "";
                                
                                domicilioSinNum = domicilioSeparado[0];
                                
                                //custTable.Rows.Add(counter, dbRow["CUENTA"], nombre, paterno, materno, domicilioSinNum, domicilioSeparado.Last(), tipoEntidad);
                                numExt = domicilioSeparado.Last();
                            }
                            else
                            {
                                //custTable.Rows.Add(counter, dbRow["CUENTA"], nombre, paterno, materno, domicilio, null, tipoEntidad);
                                numExt = string.Empty;
                            }
                        }
                        counter++;
                    }
                    if (checaDuplicados(NombreCompleto, mySqlConnection, dbRow["CUENTA"].ToString()))
                    {
                        if (!empresa)
                        {
                            try
                            {
                                //Log Entidad
                                var cmdEntidad = new SqlCommand();
                                cmdEntidad.Parameters.Clear();
                                cmdEntidad.Connection = mySqlConnection;
                                cmdEntidad.CommandType = CommandType.Text;
                                cmdEntidad.CommandText = @"INSERT INTO [Tomin].[TominRH].[Entidad] "
                                + "([Id_Entidad],[Nombre],[RFC],[Id_TipoEntidad]) "
                                + " Values (@id_entidad, @nombre, 'VACIO', 3)";
                                cmdEntidad.Parameters.AddWithValue("@id_entidad", dbRow["CUENTA"].ToString().Trim());
                                cmdEntidad.Parameters.AddWithValue("@nombre", NombreCompleto ?? string.Empty);
                                cmdEntidad.ExecuteNonQuery();
                            }
                            catch (Exception e)
                            {
                                MessageBox.Show("Entidad persona  " + e.ToString());
                            }
                        }
                        else
                        {
                            try
                            {
                                //Log Entidad
                                var cmdEntidad = new SqlCommand();
                                cmdEntidad.Parameters.Clear();
                                cmdEntidad.Connection = mySqlConnection;
                                cmdEntidad.CommandType = CommandType.Text;
                                cmdEntidad.CommandText = @"INSERT INTO [Tomin].[TominRH].[Entidad] "
                                    + "([Id_Entidad],[Nombre],[RFC],[Id_TipoEntidad]) "
                                + " Values (@id_entidad, @nombre, 'VACIO', 4)";
                                cmdEntidad.Parameters.AddWithValue("@id_entidad",dbRow["CUENTA"].ToString().Trim());
                                cmdEntidad.Parameters.AddWithValue("@nombre", NombreCompleto ?? string.Empty);
                                cmdEntidad.ExecuteNonQuery();
                            }
                            catch (Exception e)
                            {
                                MessageBox.Show("Entidad empresa  " + e.ToString());
                            }
                        }
                                       
                    if (!empresa)
                    {
                        if ((paterno == null) && (materno == null))
                        {
                            try
                            {
                                var cmdEmpresa = new SqlCommand();
                                cmdEmpresa.Parameters.Clear();
                                cmdEmpresa.Connection = mySqlConnection;
                                cmdEmpresa.CommandType = CommandType.Text;
                                cmdEmpresa.CommandText = @"INSERT INTO [Tomin].[TominRH].[Empresa] "
                                    + "([Id_Entidad],[Nombre],[WebPage],[Representante])"
                                    + " Values (@id_entidad, @nombre, 'MAIL', 'Representante')";
                                cmdEmpresa.Parameters.AddWithValue("@id_entidad", dbRow["CUENTA"].ToString().Trim());
                                cmdEmpresa.Parameters.AddWithValue("@nombre", NombreCompleto ?? string.Empty);
                                cmdEmpresa.ExecuteNonQuery();
                            }
                            catch (Exception e)
                            {
                              MessageBox.Show("Empresa  " + e.ToString());
                            }
                        }
                        else
                        {
                            try
                            {
                                var cmdPersona_Log = new SqlCommand();
                                cmdPersona_Log.Parameters.Clear();
                                cmdPersona_Log.Connection = mySqlConnection;
                                cmdPersona_Log.CommandType = CommandType.Text;
                                cmdPersona_Log.CommandText = @"INSERT INTO [Tomin].[TominRH].[Persona] "
                                    + "([Id_Entidad],[Nombre],[Paterno],[Materno],[Sexo],[Id_Nacionalidad], [FechaNacimiento])"
                                    + " Values ( @id_entidad, @nombre, @paterno, @materno, 1, 52, '01-01-1900')";
                                cmdPersona_Log.Parameters.AddWithValue("@id_entidad", dbRow["CUENTA"].ToString().Trim());
                                cmdPersona_Log.Parameters.AddWithValue("@nombre", nombre ?? string.Empty);
                                cmdPersona_Log.Parameters.AddWithValue("@paterno", paterno ?? string.Empty);
                                cmdPersona_Log.Parameters.AddWithValue("@materno", materno ?? string.Empty);
                                cmdPersona_Log.ExecuteNonQuery();
                            }
                            catch (Exception e)
                            {
                                MessageBox.Show(dbRow["CUENTA"] + " Persona  " + e.ToString());
                            }
                        }
                    }
                    else 
                    {
                        try
                        {
                            var cmdEmpresa = new SqlCommand();
                            cmdEmpresa.Parameters.Clear();
                            cmdEmpresa.Connection = mySqlConnection;
                            cmdEmpresa.CommandType = CommandType.Text;
                            cmdEmpresa.CommandText = @"INSERT INTO [Tomin].[TominRH].[Empresa] "
                                + "([Id_Entidad],[Nombre],[WebPage],[Representante])"
                                + " Values (@id_entidad, @nombre, 'MAIL', 'Representante')";
                            cmdEmpresa.Parameters.AddWithValue("@id_entidad", dbRow["CUENTA"].ToString().Trim());
                            cmdEmpresa.Parameters.AddWithValue("@nombre", NombreCompleto ?? string.Empty);
                            cmdEmpresa.ExecuteNonQuery();
                        }
                        catch (Exception e)
                        {
                           MessageBox.Show("Empresa2  " + e.ToString());
                        }

                    }
                    try
                    {
                        //Log Entidad
                        var cmdEntidadLog = new SqlCommand();
                        cmdEntidadLog.Parameters.Clear();
                        cmdEntidadLog.Connection = mySqlConnection;
                        cmdEntidadLog.CommandType = CommandType.Text;
                        cmdEntidadLog.CommandText = @"INSERT INTO [Tomin].[TominRH].[Direccion] "
                            + "([Id_Entidad],[Id_TipoDireccion],[Calle],[NumeroExt],[CP],[Colonia],[Comunidad],[Id_Ciudad],[Id_User],[Id_Date]) "
                            + " Values (@id_entidad, 1, @calle, @numExt, 98600, @colonia, @comunidad, 17, 'Admin', @fecha)";
                        cmdEntidadLog.Parameters.AddWithValue("@id_entidad", dbRow["CUENTA"].ToString().Trim());
                        cmdEntidadLog.Parameters.AddWithValue("@calle", dbRow["DOMICILIO"].ToString().Trim());
                        cmdEntidadLog.Parameters.AddWithValue("@numExt", numExt ?? string.Empty);
                        cmdEntidadLog.Parameters.AddWithValue("@colonia", dbRow["COLONIA"].ToString().Trim());
                        cmdEntidadLog.Parameters.AddWithValue("@comunidad", dbRow["CIUDAD"].ToString().Trim());
                        cmdEntidadLog.Parameters.AddWithValue("@fecha", DateTime.Now);
                        cmdEntidadLog.ExecuteNonQuery();
                        
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(numExt + " Direccion  " + e.ToString());
                    }
                    if (!empresa)
                    {
                        try
                        {
                            //Log Entidad
                            var cmdEntidadLog = new SqlCommand();
                            cmdEntidadLog.Parameters.Clear();
                            cmdEntidadLog.Connection = mySqlConnection;
                            cmdEntidadLog.CommandType = CommandType.Text;
                            cmdEntidadLog.CommandText = @"INSERT INTO [Tomin].[TominRH].[Entidad_Log] "
                                + "([Id_Action],[Id_User],[Id_Date],[Id_Entidad],[Nombre],[RFC],[Email],[Id_TipoEntidad]) "
                                + " Values (1, 'Admin', @fecha, @id_entidad, @nombre, 'VACIO', 'MAIL', 3)";
                            cmdEntidadLog.Parameters.AddWithValue("@fecha", DateTime.Now);
                            cmdEntidadLog.Parameters.AddWithValue("@id_entidad", dbRow["CUENTA"].ToString().Trim());
                            cmdEntidadLog.Parameters.AddWithValue("@nombre", NombreCompleto ?? string.Empty);
                            cmdEntidadLog.ExecuteNonQuery();
                        }
                        catch (Exception e)
                        {
                           MessageBox.Show("Entidad_log persona  "+e.ToString());
                        }
                    }
                    else
                    {
                        try
                        {
                            //Log Entidad
                            var cmdEntidadLog = new SqlCommand();
                            cmdEntidadLog.Parameters.Clear();
                            cmdEntidadLog.Connection = mySqlConnection;
                            cmdEntidadLog.CommandType = CommandType.Text;
                            cmdEntidadLog.CommandText = @"INSERT INTO [Tomin].[TominRH].[Entidad_Log] "
                                + "([Id_Action],[Id_User],[Id_Date],[Id_Entidad],[Nombre],[RFC],[Email],[Id_TipoEntidad]) "
                                + " Values (1, 'Admin', @fecha, @id_entidad, @nombre, 'VACIO', 'MAIL', 4)";
                            cmdEntidadLog.Parameters.AddWithValue("@fecha", DateTime.Now);
                            cmdEntidadLog.Parameters.AddWithValue("@id_entidad", dbRow["CUENTA"].ToString().Trim());
                            cmdEntidadLog.Parameters.AddWithValue("@nombre", NombreCompleto ?? string.Empty);
                            cmdEntidadLog.ExecuteNonQuery();
                        }
                        catch (Exception e)
                        {
                           MessageBox.Show("Entidad_log empresa" + e.ToString());
                        }
                    }
                    
                    if (!empresa)
                    {
                        if ((paterno == null) && (materno == null))
                        {
                            try
                            {
                                var cmdEmpresa_Log = new SqlCommand();
                                cmdEmpresa_Log.Parameters.Clear();
                                cmdEmpresa_Log.Connection = mySqlConnection;
                                cmdEmpresa_Log.CommandType = CommandType.Text;
                                cmdEmpresa_Log.CommandText = @"INSERT INTO [Tomin].[TominRH].[Empresa_Log] "
                                    + "([Id_Action],[Id_User],[Id_Date],[Id_Entidad],[Nombre],[WebPage],[Representante])"
                                    + " Values (1, 'Admin', @fecha, @id_entidad, @nombre, 'MAIL', 'Representante')";
                                cmdEmpresa_Log.Parameters.AddWithValue("@fecha", DateTime.Now);
                                cmdEmpresa_Log.Parameters.AddWithValue("@id_entidad", dbRow["CUENTA"].ToString().Trim());
                                cmdEmpresa_Log.Parameters.AddWithValue("@nombre", NombreCompleto ?? string.Empty);
                                cmdEmpresa_Log.ExecuteNonQuery();
                            }
                            catch(Exception e) 
                            {
                               MessageBox.Show("Empresa_log  " + e.ToString());
                            }
                                
                        }
                        else
                        {
                            try{
                                var cmdPersona_Log = new SqlCommand();
                                cmdPersona_Log.Parameters.Clear();
                                cmdPersona_Log.Connection = mySqlConnection;
                                cmdPersona_Log.CommandType = CommandType.Text;
                                cmdPersona_Log.CommandText = @"INSERT INTO [Tomin].[TominRH].[Persona_Log] "
                                    + "([Id_Action],[Id_User],[Id_Date],[Id_Entidad],[Nombre],[Paterno],[Materno],[Sexo], [FechaNacimiento],[Id_Nacionalidad])"
                                    + " Values (1, 'Admin', @fecha, @id_entidad, @nombre, @paterno, @materno, @sexo, '01-01-1900' , 52)";
                                cmdPersona_Log.Parameters.AddWithValue("@fecha", DateTime.Now);
                                cmdPersona_Log.Parameters.AddWithValue("@id_entidad", dbRow["CUENTA"].ToString().Trim());
                                cmdPersona_Log.Parameters.AddWithValue("@nombre", nombre ?? string.Empty);
                                cmdPersona_Log.Parameters.AddWithValue("@paterno", paterno ?? string.Empty);
                                cmdPersona_Log.Parameters.AddWithValue("@materno", materno ?? string.Empty);
                                cmdPersona_Log.Parameters.AddWithValue("@sexo", true);
                                cmdPersona_Log.ExecuteNonQuery();
                            }
                            catch(Exception e) 
                            {
                              MessageBox.Show(dbRow["CUENTA"] + " Persona_log  " + e.ToString());
                            }
                        }
                    }
                    else
                    {
                        try{
                            var cmdEmpresa_Log = new SqlCommand();
                            cmdEmpresa_Log.Parameters.Clear();
                            cmdEmpresa_Log.Connection = mySqlConnection;
                            cmdEmpresa_Log.CommandType = CommandType.Text;
                            cmdEmpresa_Log.CommandText = @"INSERT INTO [Tomin].[TominRH].[Empresa_Log] "
                                + "([Id_Action],[Id_User],[Id_Date],[Id_Entidad],[Nombre],[WebPage],[Representante])"
                                + " Values (1, 'Admin', @fecha, @id_entidad, '@nombre', 'MAIL', 'Representante')";
                            cmdEmpresa_Log.Parameters.AddWithValue("@fecha", DateTime.Now);
                            cmdEmpresa_Log.Parameters.AddWithValue("@id_entidad", dbRow["CUENTA"].ToString().Trim());
                            cmdEmpresa_Log.Parameters.AddWithValue("@nombre", NombreCompleto ?? string.Empty);
                            cmdEmpresa_Log.ExecuteNonQuery();
                        }
                        catch(Exception e) 
                        {
                          MessageBox.Show("Empresa_log2  " + e.ToString());
                        }
                    }
    

                    }

                } // termina foreach (DataRow dbRow in dbTable.Rows)

               

            }
            catch // (Exception e) // Exception Removed
            {
                return;
            } // catch
            

            int conta = 0;

            try
            {


                // Open Drawing Database
                //connDBF.Open();
                string jobData1 = "SELECT * FROM PREDIO.DBF";

                OdbcCommand cmd = new OdbcCommand();
                cmd.CommandText = (jobData1);

                OdbcDataAdapter dbAdapter = new OdbcDataAdapter(jobData1, connDBF);

                DataSet dtSet1234 = new DataSet();
                dbAdapter.Fill(dtSet1234);

                DataTable dbTable1234 = dtSet1234.Tables[0];

                foreach (DataRow dbRow in dbTable1234.Rows)
                {
                    int id_col = 0;
                    int id_calle = 0;
                    int id_com = 0;
                    string tipoPredio = dbRow["TIPO_PRED"].ToString().Trim();
                    int idPoblacion = Convert.ToInt32(dbRow["ID_POB"].ToString().Trim());

                    if (Regex.IsMatch(tipoPredio, @"U") && tipoPredio != "")
                    {
                        if (insertaPredio(mySqlConnection, dbRow, tipoPredio))
                        {

                            //insertaPredioLog(mySqlConnection, dbRow, tipoPredio);
                            insertaPredioContribuyente(mySqlConnection, dbRow);
                            //insertaPredioContribuyenteLog(mySqlConnection, dbRow);
                            insertaPredioCatalogo(mySqlConnection, dbRow, tipoPredio, 1, "U_ZONA");
                            insertaPredioCatalogoSN(mySqlConnection, dbRow, tipoPredio, 2, "U_BALDIO");
                            insertaPredioCatalogo(mySqlConnection, dbRow, tipoPredio, 3, "REGPROP");
                            insertaPredioCatalogo(mySqlConnection, dbRow, tipoPredio, 4, "UE_FORMA");
                            insertaPredioCatalogoSNP(mySqlConnection, dbRow, tipoPredio, 5, "RENTADO");
                            insertaPredioCatalogoSN(mySqlConnection, dbRow, tipoPredio, 6, "UE_ELEC");
                            insertaPredioCatalogoSN(mySqlConnection, dbRow, tipoPredio, 7, "UE_TELE");
                            insertaPredioCatalogoSN(mySqlConnection, dbRow, tipoPredio, 8, "UE_AGUA");
                            insertaPredioCatalogoSN(mySqlConnection, dbRow, tipoPredio, 9, "UE_DREN");
                            insertaPredioCatalogoSN(mySqlConnection, dbRow, tipoPredio, 10, "UE_ALUM");
                            insertaPredioCatalogoSN(mySqlConnection, dbRow, tipoPredio, 11, "UE_BANQ");
                            insertaPredioCatalogo(mySqlConnection, dbRow, tipoPredio, 12, "UE_PAVI");
                            insertaPredioCatalogo(mySqlConnection, dbRow, tipoPredio, 13, "U_ZONACAT");
                            insertaPredioCatalogo(mySqlConnection, dbRow, tipoPredio, 14, "U_ESTFIS");
                            insertaPredioCatalogoUso(mySqlConnection, dbRow, tipoPredio, 15, "UE_USOPRE");

                            if (idPoblacion >= 27)
                            {
                                var col = checaColDuplicados(mySqlConnection, dbRow["COLONIAP"].ToString().Trim(), idPoblacion - 2, conta);
                                id_col = Convert.ToInt32(col);
                                string calleSN = checaDomNumero(dbRow["UBICA"].ToString().Trim());
                                var calle = insertaCallesPredio(mySqlConnection, calleSN, id_col);
                                id_calle = Convert.ToInt32(calle);
                                insertaUrbano(mySqlConnection, dbRow, id_calle);
                                //insertaUrbanoLog(mySqlConnection, dbRow, id_calle);
                            }
                            else if (idPoblacion > 0 && idPoblacion < 4)
                            {
                                var col = checaColDuplicados(mySqlConnection, dbRow["COLONIAP"].ToString().Trim(), idPoblacion, conta);
                                id_col = Convert.ToInt32(col);
                                string calleSN = checaDomNumero(dbRow["UBICA"].ToString().Trim());
                                var calle = insertaCallesPredio(mySqlConnection, calleSN, id_col);
                                id_calle = Convert.ToInt32(calle);
                                insertaUrbano(mySqlConnection, dbRow, id_calle);
                                //insertaUrbanoLog(mySqlConnection, dbRow, id_calle);
                            }
                            else if (idPoblacion >= 4 && idPoblacion < 27)
                            {
                                var col = checaColDuplicados(mySqlConnection, dbRow["COLONIAP"].ToString().Trim(), idPoblacion - 1, conta);
                                id_col = Convert.ToInt32(col);
                                string calleSN = checaDomNumero(dbRow["UBICA"].ToString().Trim());
                                var calle = insertaCallesPredio(mySqlConnection, calleSN, id_col);
                                id_calle = Convert.ToInt32(calle);
                                insertaUrbano(mySqlConnection, dbRow, id_calle);
                                //insertaUrbanoLog(mySqlConnection, dbRow, id_calle);
                            }
                        }

                    }
                    else if (Regex.IsMatch(tipoPredio, @"R"))
                    {
                        if (insertaPredio(mySqlConnection, dbRow, tipoPredio))
                        {

                            //insertaPredioLog(mySqlConnection, dbRow, tipoPredio);
                            insertaPredioContribuyente(mySqlConnection, dbRow);
                            //insertaPredioContribuyenteLog(mySqlConnection, dbRow);
                            insertaPredioCatalogoSN(mySqlConnection, dbRow, tipoPredio, 6, "RE_ELEC");
                            insertaPredioCatalogo(mySqlConnection, dbRow, tipoPredio, 3, "REGPROP");
                            insertaPredioCatalogo(mySqlConnection, dbRow, tipoPredio, 16, "RE_ACCESO");
                            insertaPredioCatalogo(mySqlConnection, dbRow, tipoPredio, 17, "RE_PEDREG");
                            insertaPredioCatalogoSN(mySqlConnection, dbRow, tipoPredio, 18, "RE_POZO");
                            insertaPredioCatalogoSN(mySqlConnection, dbRow, tipoPredio, 19, "RE_PRESA");
                            insertaPredioCatalogoSN(mySqlConnection, dbRow, tipoPredio, 20, "RE_BORDO");
                            if (idPoblacion >= 27)
                            {
                                var com = checaComDuplicados(mySqlConnection, dbRow["COLONIAP"].ToString().Trim(), idPoblacion - 2, conta);
                                id_com = Convert.ToInt32(com);
                                //MessageBox.Show("Comunidad: "+id_com);
                                insertaRustico(mySqlConnection, dbRow, id_com);
                                //insertaRusticoLog(mySqlConnection, dbRow, id_com);
                            }
                            else if (idPoblacion > 0 && idPoblacion < 4)
                            {
                                var com = checaComDuplicados(mySqlConnection, dbRow["COLONIAP"].ToString().Trim(), idPoblacion, conta);
                                id_com = Convert.ToInt32(com);
                                //MessageBox.Show("Comunidad: " + id_com);
                                insertaRustico(mySqlConnection, dbRow, id_com);
                                //insertaRusticoLog(mySqlConnection, dbRow, id_com);
                            }
                            else if (idPoblacion >= 4 && idPoblacion < 27)
                            {
                                var com = checaComDuplicados(mySqlConnection, dbRow["COLONIAP"].ToString().Trim(), idPoblacion - 1, conta);
                                id_com = Convert.ToInt32(com);
                                //MessageBox.Show("Comunidad: " + id_com);
                                insertaRustico(mySqlConnection, dbRow, id_com);
                                //insertaRusticoLog(mySqlConnection, dbRow, id_com);
                            }
                        }
                    }
                    else
                    {
                        //MessageBox.Show("No tipo " + dbRow["ID_POB"]);
                    }


                } // termina foreach
            }
            catch (Exception e) // Exception Removed
            {
                MessageBox.Show(e.ToString());
                return;
            }
            
            

            creaVistaPredio(mySqlConnection);
            try
            {
                //if (System.IO.File.Exists(@"C:\DATOS1\PD_COLMED.DBF"))
                //MessageBox.Show("Existe");
                string jobData2 = @"SELECT * FROM colin.DBF";

                OdbcCommand cmd = new OdbcCommand();
                cmd.CommandText = (jobData2);

                OdbcDataAdapter dbAdapter = new OdbcDataAdapter(jobData2, connDBF);

                DataSet dtSetColindancias = new DataSet();
                dbAdapter.Fill(dtSetColindancias);
                //MessageBox.Show("Si entra");
                DataTable dbTableColindancias = dtSetColindancias.Tables[0];

                foreach (DataRow dbRow in dbTableColindancias.Rows)
                {
                    if (checaPredio(mySqlConnection, dbRow, "Clave") != null)
                    {
                        string buena = checaPredio(mySqlConnection, dbRow, "Clave");
                        insertaColindancias(mySqlConnection, dbRow, buena);
                    }
                    else if (checaPredio(mySqlConnection, dbRow, "ClaveAnt") != null)
                    {
                        string buena = checaPredio(mySqlConnection, dbRow, "ClaveAnt");
                        insertaColindancias(mySqlConnection, dbRow, buena);
                    }
                }
                /*
                foreach (DataRow dbRow in dbTableColindancias.Rows)
                {
                    insertaColindanciasLog(mySqlConnection, dbRow);
                }*/

                foreach (DataRow dbRow in dbTableColindancias.Rows)
                {
                    if (checaPredio(mySqlConnection, dbRow, "Clave") != null)
                    {
                        string buena = checaPredio(mySqlConnection, dbRow, "Clave");
                        insertaColinCata(mySqlConnection, dbRow, buena);
                    }else if(checaPredio(mySqlConnection, dbRow, "ClaveAnt") != null){
                        string buena = checaPredio(mySqlConnection, dbRow, "ClaveAnt");
                        insertaColinCata(mySqlConnection, dbRow, buena);
                    }
                }

                /*foreach (DataRow dbRow in dbTableColindancias.Rows)
                {
                    insertaColinCataLog(mySqlConnection, dbRow);
                }*/


            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

            
            try
            {
                string jobData2 = @"SELECT * FROM PD_SUPR.DBF";

                OdbcCommand cmd = new OdbcCommand();
                cmd.CommandText = (jobData2);

                OdbcDataAdapter dbAdapter = new OdbcDataAdapter(jobData2, connDBF);

                DataSet dtSetSuperficies = new DataSet();
                dbAdapter.Fill(dtSetSuperficies);
                //MessageBox.Show("Si entra");
                DataTable dbTableSuperficies = dtSetSuperficies.Tables[0];
                foreach (DataRow dbRow in dbTableSuperficies.Rows)
                {
                    if (checaPredio(mySqlConnection, dbRow, "Clave") != null)
                    {
                        string buena = checaPredio(mySqlConnection, dbRow, "Clave");
                        insertaSuperficies(mySqlConnection, dbRow, buena);
                    }
                    else if (checaPredio(mySqlConnection, dbRow, "ClaveAnt") != null)
                    {
                        string buena = checaPredio(mySqlConnection, dbRow, "ClaveAnt");
                        insertaSuperficies(mySqlConnection, dbRow, buena);
                    }
                }
                /*foreach (DataRow dbRow in dbTableSuperficies.Rows)
                {
                    insertaSuperficiesLog(mySqlConnection, dbRow);
                }*/
                foreach (DataRow dbRow in dbTableSuperficies.Rows)
                {
                    if (checaPredio(mySqlConnection, dbRow, "Clave") != null)
                    {
                        string buena = checaPredio(mySqlConnection, dbRow, "Clave");
                        insertaSuperCata(mySqlConnection, dbRow, "R", 26, "USO", buena);
                    }
                    else if (checaPredio(mySqlConnection, dbRow, "ClaveAnt") != null)
                    {
                        string buena = checaPredio(mySqlConnection, dbRow, "ClaveAnt");
                        insertaSuperCata(mySqlConnection, dbRow, "R", 26, "USO", buena);
                    }
                    
                }
                foreach (DataRow dbRow in dbTableSuperficies.Rows)
                {
                    if (checaPredio(mySqlConnection, dbRow, "Clave") != null)
                    {
                        string buena = checaPredio(mySqlConnection, dbRow, "Clave");
                        insertaSuperCata(mySqlConnection, dbRow, "R", 27, "TIPO_RIE", buena);
                    }
                    else if (checaPredio(mySqlConnection, dbRow, "ClaveAnt") != null)
                    {
                        string buena = checaPredio(mySqlConnection, dbRow, "ClaveAnt");
                        insertaSuperCata(mySqlConnection, dbRow, "R", 27, "TIPO_RIE", buena);
                    }
                }
                foreach (DataRow dbRow in dbTableSuperficies.Rows)
                {
                    if (checaPredio(mySqlConnection, dbRow, "Clave") != null)
                    {
                        string buena = checaPredio(mySqlConnection, dbRow, "Clave");
                        insertaSuperCata(mySqlConnection, dbRow, "R", 28, "TIPO", buena);
                    }
                    else if (checaPredio(mySqlConnection, dbRow, "ClaveAnt") != null)
                    {
                        string buena = checaPredio(mySqlConnection, dbRow, "ClaveAnt");
                        insertaSuperCata(mySqlConnection, dbRow, "R", 28, "TIPO", buena);
                    }
                }
                /*foreach (DataRow dbRow in dbTableSuperficies.Rows)
                {
                    insertaSuperCataLog(mySqlConnection, dbRow, "R", 26, "USO");
                }
                foreach (DataRow dbRow in dbTableSuperficies.Rows)
                {
                    insertaSuperCataLog(mySqlConnection, dbRow, "R", 27, "TIPO_RIE");
                }
                foreach (DataRow dbRow in dbTableSuperficies.Rows)
                {
                    insertaSuperCataLog(mySqlConnection, dbRow, "R", 28, "TIPO");
                }*/
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

            try
            {
                string jobData2 = @"SELECT * FROM PD_CONST.DBF";

                OdbcCommand cmd = new OdbcCommand();
                cmd.CommandText = (jobData2);

                OdbcDataAdapter dbAdapter = new OdbcDataAdapter(jobData2, connDBF);

                DataSet dtSetSuperficies = new DataSet();
                dbAdapter.Fill(dtSetSuperficies);
                //MessageBox.Show("Si entra");
                DataTable dbTableSuperficies = dtSetSuperficies.Tables[0];
                foreach (DataRow dbRow in dbTableSuperficies.Rows)
                {
                    if (checaPredio(mySqlConnection, dbRow, "Clave") != null)
                    {
                        string buena = checaPredio(mySqlConnection, dbRow, "Clave");
                        insertaSuperficies(mySqlConnection, dbRow, buena);
                    }
                    else if (checaPredio(mySqlConnection, dbRow, "ClaveAnt") != null)
                    {
                        string buena = checaPredio(mySqlConnection, dbRow, "ClaveAnt");
                        insertaSuperficies(mySqlConnection, dbRow, buena);
                    }
                }
                /*foreach (DataRow dbRow in dbTableSuperficies.Rows)
                {
                    insertaSuperficiesLog(mySqlConnection, dbRow);
                }*/

                foreach (DataRow dbRow in dbTableSuperficies.Rows)
                {
                    if (checaPredio(mySqlConnection, dbRow, "Clave") != null)
                    {
                        string buena = checaPredio(mySqlConnection, dbRow, "Clave");
                        insertaSuperCata(mySqlConnection, dbRow, "U", 22, "TIPO", buena);
                    }
                    else if (checaPredio(mySqlConnection, dbRow, "ClaveAnt") != null)
                    {
                        string buena = checaPredio(mySqlConnection, dbRow, "ClaveAnt");
                        insertaSuperCata(mySqlConnection, dbRow, "U", 22, "TIPO", buena);
                    }
                }
                foreach (DataRow dbRow in dbTableSuperficies.Rows)
                {
                    if (checaPredio(mySqlConnection, dbRow, "Clave") != null)
                    {
                        string buena = checaPredio(mySqlConnection, dbRow, "Clave");
                        insertaSuperCata(mySqlConnection, dbRow, "U", 23, "USO", buena);
                    }
                    else if (checaPredio(mySqlConnection, dbRow, "ClaveAnt") != null)
                    {
                        string buena = checaPredio(mySqlConnection, dbRow, "ClaveAnt");
                        insertaSuperCata(mySqlConnection, dbRow, "U", 23, "USO", buena);
                    }
                }
                foreach (DataRow dbRow in dbTableSuperficies.Rows)
                {
                    if (checaPredio(mySqlConnection, dbRow, "Clave") != null)
                    {
                        string buena = checaPredio(mySqlConnection, dbRow, "Clave");
                        insertaSuperCata(mySqlConnection, dbRow, "U", 24, "CALIDAD", buena);
                    }
                    else if (checaPredio(mySqlConnection, dbRow, "ClaveAnt") != null)
                    {
                        string buena = checaPredio(mySqlConnection, dbRow, "ClaveAnt");
                        insertaSuperCata(mySqlConnection, dbRow, "U", 24, "CALIDAD", buena);
                    }
                }
                foreach (DataRow dbRow in dbTableSuperficies.Rows)
                {
                    if (checaPredio(mySqlConnection, dbRow, "Clave") != null)
                    {
                        string buena = checaPredio(mySqlConnection, dbRow, "Clave");
                        insertaSuperCata(mySqlConnection, dbRow, "U", 25, "ESTADO", buena);
                    }
                    else if (checaPredio(mySqlConnection, dbRow, "ClaveAnt") != null)
                    {
                        string buena = checaPredio(mySqlConnection, dbRow, "ClaveAnt");
                        insertaSuperCata(mySqlConnection, dbRow, "U", 25, "ESTADO", buena);
                    }
                }
                /*foreach (DataRow dbRow in dbTableSuperficies.Rows)
                {
                    insertaSuperCataLog(mySqlConnection, dbRow, "U", 22, "TIPO");
                }
                foreach (DataRow dbRow in dbTableSuperficies.Rows)
                {
                    insertaSuperCataLog(mySqlConnection, dbRow, "U", 23, "USO");
                }
                foreach (DataRow dbRow in dbTableSuperficies.Rows)
                {
                    insertaSuperCataLog(mySqlConnection, dbRow, "U", 24, "CALIDAD");
                }
                foreach (DataRow dbRow in dbTableSuperficies.Rows)
                {
                    insertaSuperCataLog(mySqlConnection, dbRow, "U", 25, "ESTADO");
                }*/
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            /*
                          try
                          {
                              string jobData2 = @"SELECT * FROM NM.DBF";

                              OdbcCommand cmd = new OdbcCommand();
                              cmd.CommandText = (jobData2);

                              OdbcDataAdapter dbAdapter = new OdbcDataAdapter(jobData2, connDBF);

                              DataSet dtSetNM = new DataSet();
                              dbAdapter.Fill(dtSetNM);
                              MessageBox.Show("Si entra NM");
                              DataTable dbTableNM = dtSetNM.Tables[0];

                              foreach (DataRow dbRow in dbTableNM.Rows)
                              {
                                  insertaDNM(mySqlConnection, dbRow);
                              }
                
                          }
                          catch (Exception e)
                          {
                              MessageBox.Show(e.ToString());
                          }*/
            connDBF.Close();
            mySqlConnection.Close();

            // Create a dataset
            DataSet ds = new DataSet("Contribuyentes");
            // Add Customers table to the dataset
            //ds.Tables.Add(custTable);
            // Attach the data set to a DataGrid
            //dataGrid1.DataSource = ds.DefaultViewManager;
            regularSW.Stop();
            MessageBox.Show(regularSW.Elapsed.ToString());
        }

        private void insertaDNM(SqlConnection mySqlConnection, DataRow dbRow)
        {
            try
            {
                int id = Convert.ToInt32(checaID(mySqlConnection, dbRow));
                string entidad = "";
                if (dbRow["ESTADO"].ToString().Trim() == "SAT")
                {
                    entidad = "03829S";
                }
                else
                {
                    entidad = "00000";
                }
                var cmd1 = new SqlCommand();
                cmd1.Parameters.Clear();
                cmd1.Connection = mySqlConnection;
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = @"INSERT INTO [Tomin].[TominPredial].[DetalleNotaMarginal] ([Id_NotaMarginal],[Tipo],[Fecha]"
                                    + ",[Procedencia],[Acta],[Notas],[Id_Empresa],[Id_User],[Id_Date])"
                                + " VALUES (@id_nota, @est, @fechamov, @proc, @acta, @notas, @clave, @user, @fecha)";
                cmd1.Parameters.AddWithValue("@clave", entidad);
                cmd1.Parameters.AddWithValue("@est", dbRow["ESTADO"].ToString().Trim());
                cmd1.Parameters.AddWithValue("@id_nota", id);
                cmd1.Parameters.AddWithValue("@fechamov", Convert.ToDateTime(dbRow["FECHAMOV"].ToString().Trim()));
                cmd1.Parameters.AddWithValue("@proc", dbRow["PROCEDE"].ToString().Trim());
                cmd1.Parameters.AddWithValue("@acta", dbRow["ACTA"].ToString().Trim());
                cmd1.Parameters.AddWithValue("@notas", dbRow["NOTAS"].ToString().Trim());
                cmd1.Parameters.AddWithValue("@user", "Admin");
                cmd1.Parameters.AddWithValue("@fecha", DateTime.Now);
                cmd1.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                //System.IO.File.AppendAllText(pathString, e.ToString() + Environment.NewLine);
                //System.IO.File.AppendAllText(pathString, dbRow.ToString() + Environment.NewLine);
                MessageBox.Show(e.ToString());
            }
        }

        private Object checaID(SqlConnection mySqlConnection, DataRow dbRow)
        {
            try
            {
                var cmd = new SqlCommand();
                cmd.Parameters.Clear();
                cmd.Connection = mySqlConnection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"select Id_NotaMarginal from Tomin.TominPredial.NotaMarginal where Estado = @est and Clave = @clave";
                cmd.Parameters.AddWithValue("@est", dbRow["ESTADO"].ToString().Trim());
                cmd.Parameters.AddWithValue("@clave", dbRow["CPRED"].ToString().Trim());
                return cmd.ExecuteScalar();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                System.IO.File.AppendAllText(pathString, e.ToString() + Environment.NewLine);
                System.IO.File.AppendAllText(pathString, dbRow.ToString() + Environment.NewLine);
                return -1;
            }
        }

        private void insertaPredioCatalogoUso(SqlConnection mySqlConnection, DataRow dbRow, string tipo, int tablaOp, string tabla)
        {

            try
            {
                string opcion = Convert.ToString(checaOpcion(mySqlConnection, dbRow, tablaOp, tabla));
                var cmd1 = new SqlCommand();
                cmd1.Parameters.Clear();
                cmd1.Connection = mySqlConnection;
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = @"INSERT INTO [Tomin].[TominPredial].[PredioCatalogo] ([Clave],[Id_Catalogo],[Valor],[Id_SubTipoPredio])"
                                + " VALUES (@clave, @cat, @valor, @tipo)";
                cmd1.Parameters.AddWithValue("@clave", dbRow["CPRED"].ToString().Trim());
                cmd1.Parameters.AddWithValue("@cat", tablaOp);
                cmd1.Parameters.AddWithValue("@valor", opcion);
                cmd1.Parameters.AddWithValue("@tipo", tipo);
                cmd1.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                System.IO.File.AppendAllText(pathString, e.ToString() + Environment.NewLine);
                System.IO.File.AppendAllText(pathString, dbRow.ToString() + Environment.NewLine);
                //MessageBox.Show(e.ToString());
            }
        }

        private void insertaPredioCatalogoSNP(SqlConnection mySqlConnection, DataRow dbRow, string tipo, int tablaOp, string columna)
        {
            if (dbRow[columna].ToString().Trim() == "S")
            {
                try
                {
                    var cmd1 = new SqlCommand();
                    cmd1.Parameters.Clear();
                    cmd1.Connection = mySqlConnection;
                    cmd1.CommandType = CommandType.Text;
                    cmd1.CommandText = @"INSERT INTO [Tomin].[TominPredial].[PredioCatalogo] ([Clave],[Id_Catalogo],[Valor],[Id_SubTipoPredio])"
                                    + " VALUES (@clave, @cat, @valor, @tipo)";
                    cmd1.Parameters.AddWithValue("@clave", dbRow["CPRED"].ToString().Trim());
                    cmd1.Parameters.AddWithValue("@cat", tablaOp);
                    cmd1.Parameters.AddWithValue("@valor", 1);
                    cmd1.Parameters.AddWithValue("@tipo", tipo);
                    cmd1.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    System.IO.File.AppendAllText(pathString, e.ToString() + Environment.NewLine);
                    System.IO.File.AppendAllText(pathString, dbRow.ToString() + Environment.NewLine);
                    //MessageBox.Show(e.ToString());
                }
            }
            else if (dbRow[columna].ToString().Trim() == "P")
            {
                try
                {
                    var cmd1 = new SqlCommand();
                    cmd1.Parameters.Clear();
                    cmd1.Connection = mySqlConnection;
                    cmd1.CommandType = CommandType.Text;
                    cmd1.CommandText = @"INSERT INTO [Tomin].[TominPredial].[PredioCatalogo] ([Clave],[Id_Catalogo],[Valor],[Id_SubTipoPredio])"
                                    + " VALUES (@clave, @cat, @valor, @tipo)";
                    cmd1.Parameters.AddWithValue("@clave", dbRow["CPRED"].ToString().Trim());
                    cmd1.Parameters.AddWithValue("@cat", tablaOp);
                    cmd1.Parameters.AddWithValue("@valor", 2);
                    cmd1.Parameters.AddWithValue("@tipo", tipo);
                    cmd1.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    System.IO.File.AppendAllText(pathString, e.ToString() + Environment.NewLine);
                    System.IO.File.AppendAllText(pathString, dbRow.ToString() + Environment.NewLine);
                    //MessageBox.Show(e.ToString());
                }
            }
            else if (dbRow[columna].ToString().Trim() == "N")
            {
                try
                {
                    var cmd1 = new SqlCommand();
                    cmd1.Parameters.Clear();
                    cmd1.Connection = mySqlConnection;
                    cmd1.CommandType = CommandType.Text;
                    cmd1.CommandText = @"INSERT INTO [Tomin].[TominPredial].[PredioCatalogo] ([Clave],[Id_Catalogo],[Valor],[Id_SubTipoPredio])"
                                    + " VALUES (@clave, @cat, @valor, @tipo)";
                    cmd1.Parameters.AddWithValue("@clave", dbRow["CPRED"].ToString().Trim());
                    cmd1.Parameters.AddWithValue("@cat", tablaOp);
                    cmd1.Parameters.AddWithValue("@valor", 3);
                    cmd1.Parameters.AddWithValue("@tipo", tipo);
                    cmd1.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    System.IO.File.AppendAllText(pathString, e.ToString() + Environment.NewLine);
                    System.IO.File.AppendAllText(pathString, dbRow.ToString() + Environment.NewLine);
                    //MessageBox.Show(e.ToString());
                }
            }
        }

        private void insertaPredioCatalogoSN(SqlConnection mySqlConnection, DataRow dbRow, string tipo, int tablaOp, string columna)
        {
            if (dbRow[columna].ToString().Trim() == "S")
            {
                try
                {
                    var cmd1 = new SqlCommand();
                    cmd1.Parameters.Clear();
                    cmd1.Connection = mySqlConnection;
                    cmd1.CommandType = CommandType.Text;
                    cmd1.CommandText = @"INSERT INTO [Tomin].[TominPredial].[PredioCatalogo] ([Clave],[Id_Catalogo],[Valor],[Id_SubTipoPredio])"
                                    + " VALUES (@clave, @cat, @valor, @tipo)";
                    cmd1.Parameters.AddWithValue("@clave", dbRow["CPRED"].ToString().Trim());
                    cmd1.Parameters.AddWithValue("@cat", tablaOp);
                    cmd1.Parameters.AddWithValue("@valor", 1);
                    cmd1.Parameters.AddWithValue("@tipo", tipo);
                    cmd1.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    System.IO.File.AppendAllText(pathString, e.ToString() + Environment.NewLine);
                    System.IO.File.AppendAllText(pathString, dbRow.ToString() + Environment.NewLine);
                    //MessageBox.Show(e.ToString());
                }
            }
            else
            {
                try
                {
                    var cmd1 = new SqlCommand();
                    cmd1.Parameters.Clear();
                    cmd1.Connection = mySqlConnection;
                    cmd1.CommandType = CommandType.Text;
                    cmd1.CommandText = @"INSERT INTO [Tomin].[TominPredial].[PredioCatalogo] ([Clave],[Id_Catalogo],[Valor],[Id_SubTipoPredio])"
                                    + " VALUES (@clave, @cat, @valor, @tipo)";
                    cmd1.Parameters.AddWithValue("@clave", dbRow["CPRED"].ToString().Trim());
                    cmd1.Parameters.AddWithValue("@cat", tablaOp);
                    cmd1.Parameters.AddWithValue("@valor", 2);
                    cmd1.Parameters.AddWithValue("@tipo", tipo);
                    cmd1.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    System.IO.File.AppendAllText(pathString, e.ToString() + Environment.NewLine);
                    System.IO.File.AppendAllText(pathString, dbRow.ToString() + Environment.NewLine);
                    //MessageBox.Show(e.ToString());
                }
            }

        }

        private void insertaPredioCatalogo(SqlConnection mySqlConnection, DataRow dbRow, string tipo, int tablaOp, string columna)
        {
            try
            {
                var cmd1 = new SqlCommand();
                cmd1.Parameters.Clear();
                cmd1.Connection = mySqlConnection;
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = @"INSERT INTO [Tomin].[TominPredial].[PredioCatalogo] ([Clave],[Id_Catalogo],[Valor],[Id_SubTipoPredio])"
                                + " VALUES (@clave, @cat, @valor, @tipo)";
                cmd1.Parameters.AddWithValue("@clave", dbRow["CPRED"].ToString().Trim());
                cmd1.Parameters.AddWithValue("@cat", tablaOp);
                cmd1.Parameters.AddWithValue("@valor", dbRow[columna].ToString().Trim());
                cmd1.Parameters.AddWithValue("@tipo", tipo);
                cmd1.ExecuteNonQuery();
                //if (dbRow[columna].ToString().Trim() != "")
                //MessageBox.Show(dbRow[columna].ToString().Trim());
            }
            catch (Exception e)
            {
                System.IO.File.AppendAllText(pathString, e.ToString() + Environment.NewLine);
                System.IO.File.AppendAllText(pathString, dbRow.ToString() + Environment.NewLine);
                //MessageBox.Show(e.ToString());
            }
        }

        private void insertaSuperCataLog(SqlConnection mySqlConnection, DataRow dbRow, string tipo, int tablaOp, string tabla)
        {
            try
            {
                var cmd = new SqlCommand();
                cmd.Parameters.Clear();
                cmd.Connection = mySqlConnection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"select MAX(Num) from Tomin.TominPredial.SuperficieCatalogo_Log where Clave = @clave AND Id_Catalogo = @cat";
                cmd.Parameters.AddWithValue("@clave", dbRow["CPRED"].ToString().Trim());
                cmd.Parameters.AddWithValue("@cat", tablaOp);
                var num = cmd.ExecuteScalar();

                if (num.Equals(DBNull.Value))
                {
                    try
                    {
                        string opcion = Convert.ToString(checaOpcion(mySqlConnection, dbRow, tablaOp, tabla));
                        var cmd1 = new SqlCommand();
                        cmd1.Parameters.Clear();
                        cmd1.Connection = mySqlConnection;
                        cmd1.CommandType = CommandType.Text;
                        cmd1.CommandText = @"INSERT INTO [Tomin].[TominPredial].[SuperficieCatalogo_Log] ([Id_Action],[Id_User],[Id_Date],[Clave],[Num],[Id_Catalogo],[Valor],[Id_TipoPredio])"
                                            + " VALUES (@accion,@user,@fecha, @clave, @num, @cat,@valor, @tipo)";
                        cmd1.Parameters.AddWithValue("@accion", 1);
                        cmd1.Parameters.AddWithValue("@user", "Admin");
                        cmd1.Parameters.AddWithValue("@fecha", DateTime.Now);
                        cmd1.Parameters.AddWithValue("@clave", dbRow["CPRED"].ToString().Trim());
                        cmd1.Parameters.AddWithValue("@num", 1);
                        cmd1.Parameters.AddWithValue("@cat", tablaOp);
                        cmd1.Parameters.AddWithValue("@valor", opcion);
                        cmd1.Parameters.AddWithValue("@tipo", tipo);
                        cmd1.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        System.IO.File.AppendAllText(pathString, e.ToString() + Environment.NewLine);
                        System.IO.File.AppendAllText(pathString, dbRow.ToString() + Environment.NewLine);
                        //MessageBox.Show(e.ToString());
                    }
                }
                else
                {
                    try
                    {
                        string opcion = Convert.ToString(checaOpcion(mySqlConnection, dbRow, tablaOp, tabla));
                        int numero = Convert.ToInt32(num);
                        var cmd1 = new SqlCommand();
                        cmd1.Parameters.Clear();
                        cmd1.Connection = mySqlConnection;
                        cmd1.CommandType = CommandType.Text;
                        cmd1.CommandText = @"INSERT INTO [Tomin].[TominPredial].[SuperficieCatalogo_Log] ([Id_Action],[Id_User],[Id_Date],[Clave],[Num],[Id_Catalogo],[Valor],[Id_TipoPredio])"
                                            + " VALUES (@accion,@user,@fecha,@clave, @num, @cat,@valor, @tipo)";
                        cmd1.Parameters.AddWithValue("@accion", 1);
                        cmd1.Parameters.AddWithValue("@user", "Admin");
                        cmd1.Parameters.AddWithValue("@fecha", DateTime.Now);
                        cmd1.Parameters.AddWithValue("@clave", dbRow["CPRED"].ToString().Trim());
                        cmd1.Parameters.AddWithValue("@num", numero + 1);
                        cmd1.Parameters.AddWithValue("@cat", tablaOp);
                        cmd1.Parameters.AddWithValue("@valor", opcion);
                        cmd1.Parameters.AddWithValue("@tipo", tipo);
                        cmd1.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        System.IO.File.AppendAllText(pathString, e.ToString() + Environment.NewLine);
                        System.IO.File.AppendAllText(pathString, dbRow.ToString() + Environment.NewLine);
                        //MessageBox.Show(e.ToString());
                    }
                }
            }
            catch (Exception e)
            {
                System.IO.File.AppendAllText(pathString, e.ToString() + Environment.NewLine);
                System.IO.File.AppendAllText(pathString, dbRow.ToString() + Environment.NewLine);
                MessageBox.Show(e.ToString());
            }
        }

        private void insertaSuperCata(SqlConnection mySqlConnection, DataRow dbRow, string tipo, int tablaOp, string tabla, string buena)
        {
            try
            {
                var cmd = new SqlCommand();
                cmd.Parameters.Clear();
                cmd.Connection = mySqlConnection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"select MAX(Num) from Tomin.TominPredial.SuperficieCatalogo where Clave = @clave AND Id_Catalogo = @cat";
                cmd.Parameters.AddWithValue("@clave", buena);
                cmd.Parameters.AddWithValue("@cat", tablaOp);
                var num = cmd.ExecuteScalar();

                if (num.Equals(DBNull.Value))
                {
                    try
                    {
                        string opcion = Convert.ToString(checaOpcion(mySqlConnection, dbRow, tablaOp, tabla));
                        var cmd1 = new SqlCommand();
                        cmd1.Parameters.Clear();
                        cmd1.Connection = mySqlConnection;
                        cmd1.CommandType = CommandType.Text;
                        cmd1.CommandText = @"INSERT INTO [Tomin].[TominPredial].[SuperficieCatalogo] ([Clave],[Num],[Id_Catalogo],[Valor],[Id_TipoPredio])"
                                            + " VALUES (@clave, @num, @cat,@valor, @tipo)";
                        cmd1.Parameters.AddWithValue("@clave", buena);
                        cmd1.Parameters.AddWithValue("@num", 1);
                        cmd1.Parameters.AddWithValue("@cat", tablaOp);
                        cmd1.Parameters.AddWithValue("@valor", opcion);
                        cmd1.Parameters.AddWithValue("@tipo", tipo);
                        cmd1.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        System.IO.File.AppendAllText(pathString, e.ToString() + Environment.NewLine);
                        System.IO.File.AppendAllText(pathString, dbRow.ToString() + Environment.NewLine);
                        //MessageBox.Show(e.ToString());
                    }
                }
                else
                {
                    try
                    {
                        string opcion = Convert.ToString(checaOpcion(mySqlConnection, dbRow, tablaOp, tabla));
                        int numero = Convert.ToInt32(num);
                        var cmd1 = new SqlCommand();
                        cmd1.Parameters.Clear();
                        cmd1.Connection = mySqlConnection;
                        cmd1.CommandType = CommandType.Text;
                        cmd1.CommandText = @"INSERT INTO [Tomin].[TominPredial].[SuperficieCatalogo] ([Clave],[Num],[Id_Catalogo],[Valor],[Id_TipoPredio])"
                                            + " VALUES (@clave, @num, @cat,@valor, @tipo)";
                        cmd1.Parameters.AddWithValue("@clave", buena);
                        cmd1.Parameters.AddWithValue("@num", numero + 1);
                        cmd1.Parameters.AddWithValue("@cat", tablaOp);
                        cmd1.Parameters.AddWithValue("@valor", opcion);
                        cmd1.Parameters.AddWithValue("@tipo", tipo);
                        cmd1.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        System.IO.File.AppendAllText(pathString, e.ToString() + Environment.NewLine);
                        System.IO.File.AppendAllText(pathString, dbRow.ToString() + Environment.NewLine);
                        //MessageBox.Show(e.ToString());
                    }
                }
            }
            catch (Exception e)
            {
                System.IO.File.AppendAllText(pathString, e.ToString() + Environment.NewLine);
                System.IO.File.AppendAllText(pathString, dbRow.ToString() + Environment.NewLine);
                MessageBox.Show(e.ToString());
            }

        }

        private void insertaSuperficiesLog(SqlConnection mySqlConnection, DataRow dbRow)
        {
            //MessageBox.Show("Entro");
            try
            {
                var cmd = new SqlCommand();
                cmd.Parameters.Clear();
                cmd.Connection = mySqlConnection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"select MAX(Num) from Tomin.TominPredial.Superficie_Log Where Clave = @Clave";
                cmd.Parameters.AddWithValue("@Clave", dbRow["CPRED"].ToString().Trim());
                var num = cmd.ExecuteScalar();

                //MessageBox.Show("" + dbRow["CPRED"].ToString().Trim());
                if (num.Equals(DBNull.Value))
                {
                    //MesageBox.Show("Cero");
                    try
                    {
                        var cmd1 = new SqlCommand();
                        cmd1.Parameters.Clear();
                        cmd1.Connection = mySqlConnection;
                        cmd1.CommandType = CommandType.Text;
                        cmd1.CommandText = @"INSERT INTO [Tomin].[TominPredial].[Superficie_Log] ([Id_Action],[Id_User],[Id_Date],[Clave],[Num],[Superficie],[Niveles])"
                                            + " VALUES (@accion, @user, @fecha, @Clave,@Num,@super,@niv)";
                        cmd1.Parameters.AddWithValue("@accion", 1);
                        cmd1.Parameters.AddWithValue("@user", "Admin");
                        cmd1.Parameters.AddWithValue("@fecha", DateTime.Now);
                        cmd1.Parameters.AddWithValue("@Clave", dbRow["CPRED"].ToString().Trim());
                        cmd1.Parameters.AddWithValue("@Num", 1);
                        cmd1.Parameters.AddWithValue("@super", dbRow["SUP"].ToString().Trim());
                        try
                        {
                            cmd1.Parameters.AddWithValue("@niv", dbRow["NIVELES"].ToString().Trim());
                        }
                        catch (System.ArgumentException)
                        {
                            cmd1.Parameters.AddWithValue("@niv", 1);
                            cmd1.Parameters[6].Value = 1;
                            //MessageBox.Show(cmd1.Parameters[3].Value.ToString());
                        }
                        finally
                        {
                            cmd1.ExecuteNonQuery();
                        }
                    }
                    catch (Exception e)
                    {
                        System.IO.File.AppendAllText(pathString, e.ToString() + Environment.NewLine);
                        System.IO.File.AppendAllText(pathString, dbRow.ToString() + Environment.NewLine);
                        //MessageBox.Show(e.ToString());
                    }
                }
                else
                {
                    //MessageBox.Show("No cero");
                    int numero = Convert.ToInt32(num);
                    try
                    {
                        var cmd1 = new SqlCommand();
                        cmd1.Parameters.Clear();
                        cmd1.Connection = mySqlConnection;
                        cmd1.CommandType = CommandType.Text;
                        cmd1.CommandText = @"INSERT INTO [Tomin].[TominPredial].[Superficie_Log] ([Id_Action],[Id_User],[Id_Date],[Clave],[Num],[Superficie],[Niveles])"
                                            + " VALUES (@accion, @user, @fecha, @Clave,@Num,@super,@niv)";
                        cmd1.Parameters.AddWithValue("@accion", 1);
                        cmd1.Parameters.AddWithValue("@user", "Admin");
                        cmd1.Parameters.AddWithValue("@fecha", DateTime.Now);
                        cmd1.Parameters.AddWithValue("@Clave", dbRow["CPRED"].ToString().Trim());
                        cmd1.Parameters.AddWithValue("@Num", numero + 1);
                        cmd1.Parameters.AddWithValue("@super", dbRow["SUP"].ToString().Trim());
                        try
                        {
                            cmd1.Parameters.AddWithValue("@niv", dbRow["NIVELES"].ToString().Trim());
                        }
                        catch (System.ArgumentException)
                        {
                            cmd1.Parameters.AddWithValue("@niv", 1);
                            cmd1.Parameters[6].Value = 1;
                            //MessageBox.Show(cmd1.Parameters[3].Value.ToString());
                        }
                        finally
                        {
                            cmd1.ExecuteNonQuery();
                        }
                    }
                    catch (Exception e)
                    {
                        System.IO.File.AppendAllText(pathString, e.ToString() + Environment.NewLine);
                        System.IO.File.AppendAllText(pathString, dbRow.ToString() + Environment.NewLine);
                       //MessageBox.Show(e.ToString());
                    }
                }
            }
            catch (Exception e)
            {
                System.IO.File.AppendAllText(pathString, e.ToString() + Environment.NewLine);
                System.IO.File.AppendAllText(pathString, dbRow.ToString() + Environment.NewLine);
                MessageBox.Show(e.ToString());

            }

        }

        private void insertaSuperficies(SqlConnection mySqlConnection, DataRow dbRow, string buena)
        {
            //MessageBox.Show("Entro");
            try
            {
                var cmd = new SqlCommand();
                cmd.Parameters.Clear();
                cmd.Connection = mySqlConnection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"select MAX(Num) from Tomin.TominPredial.Superficie Where Clave = @Clave";
                cmd.Parameters.AddWithValue("@Clave", buena);
                var num = cmd.ExecuteScalar();

                //MessageBox.Show("" + dbRow["CPRED"].ToString().Trim());
                if (num.Equals(DBNull.Value))
                {
                    //MesageBox.Show("Cero");
                    try
                    {
                        var cmd1 = new SqlCommand();
                        cmd1.Parameters.Clear();
                        cmd1.Connection = mySqlConnection;
                        cmd1.CommandType = CommandType.Text;
                        cmd1.CommandText = @"INSERT INTO [Tomin].[TominPredial].[Superficie] ([Clave],[Num],[Superficie],[Niveles])"
                                            + " VALUES (@Clave,@Num,@super,@niv)";
                        cmd1.Parameters.AddWithValue("@Clave", buena);
                        cmd1.Parameters.AddWithValue("@Num", 1);
                        cmd1.Parameters.AddWithValue("@super", dbRow["SUP"].ToString().Trim());
                        try
                        {
                            cmd1.Parameters.AddWithValue("@niv", dbRow["NIVELES"].ToString().Trim());
                        }
                        catch (System.ArgumentException)
                        {
                            cmd1.Parameters.AddWithValue("@niv", 1);
                            cmd1.Parameters[3].Value = 1;
                            //MessageBox.Show(cmd1.Parameters[3].Value.ToString());
                        }
                        finally
                        {
                            cmd1.ExecuteNonQuery();
                        }
                    }
                    catch (Exception e)
                    {
                        System.IO.File.AppendAllText(pathString, e.ToString() + Environment.NewLine);
                        System.IO.File.AppendAllText(pathString, dbRow.ToString() + Environment.NewLine);
                        //MessageBox.Show(e.ToString());
                    }
                }
                else
                {
                    //MessageBox.Show("No cero");
                    int numero = Convert.ToInt32(num);
                    try
                    {
                        var cmd1 = new SqlCommand();
                        cmd1.Parameters.Clear();
                        cmd1.Connection = mySqlConnection;
                        cmd1.CommandType = CommandType.Text;
                        cmd1.CommandText = @"INSERT INTO [Tomin].[TominPredial].[Superficie] ([Clave],[Num],[Superficie],[Niveles])"
                                            + " VALUES (@Clave,@Num,@super,@niv)";
                        cmd1.Parameters.AddWithValue("@Clave", buena);
                        cmd1.Parameters.AddWithValue("@Num", numero + 1);
                        cmd1.Parameters.AddWithValue("@super", dbRow["SUP"].ToString().Trim());
                        try
                        {
                            cmd1.Parameters.AddWithValue("@niv", dbRow["NIVELES"].ToString().Trim());
                        }
                        catch (System.ArgumentException)
                        {
                            cmd1.Parameters.AddWithValue("@niv", 1);
                            cmd1.Parameters[3].Value = 1;
                            //MessageBox.Show(cmd1.Parameters[3].Value.ToString());
                        }
                        finally
                        {
                            cmd1.ExecuteNonQuery();
                        }
                    }
                    catch (Exception e)
                    {
                        System.IO.File.AppendAllText(pathString, e.ToString() + Environment.NewLine);
                        System.IO.File.AppendAllText(pathString, dbRow.ToString() + Environment.NewLine);
                       // MessageBox.Show(e.ToString());
                    }
                }
            }
            catch (Exception e)
            {
                System.IO.File.AppendAllText(pathString, e.ToString() + Environment.NewLine);
                System.IO.File.AppendAllText(pathString, dbRow.ToString() + Environment.NewLine);
                MessageBox.Show(e.ToString());

            }

        }

        private void insertaColinCataLog(SqlConnection mySqlConnection, DataRow dbRow)
        {
            try
            {
                var cmd = new SqlCommand();
                cmd.Parameters.Clear();
                cmd.Connection = mySqlConnection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"select MAX(Num) from Tomin.TominPredial.ColindanciaCatalogo_Log where Clave = @clave";
                cmd.Parameters.AddWithValue("@clave", dbRow["CPRED"].ToString().Trim());
                var num = cmd.ExecuteScalar();

                if (num.Equals(DBNull.Value))
                {
                    try
                    {
                        string opcion = Convert.ToString(checaOpcion(mySqlConnection, dbRow, 21, "ORIENTA"));
                        var cmd1 = new SqlCommand();
                        cmd1.Parameters.Clear();
                        cmd1.Connection = mySqlConnection;
                        cmd1.CommandType = CommandType.Text;
                        cmd1.CommandText = @"INSERT INTO [Tomin].[TominPredial].[ColindanciaCatalogo_Log] ([Id_Action],[Id_User],[Id_Date],[Clave],[Num],[Id_Catalogo],[Valor])"
                                            + " VALUES (@accion, @usuario, @fecha, @clave, @num, @cat,@valor)";
                        cmd1.Parameters.AddWithValue("@accion", 1);
                        cmd1.Parameters.AddWithValue("@usuario", "Admin");
                        cmd1.Parameters.AddWithValue("@fecha", DateTime.Now);
                        cmd1.Parameters.AddWithValue("@clave", dbRow["CPRED"].ToString().Trim());
                        cmd1.Parameters.AddWithValue("@num", 1);
                        cmd1.Parameters.AddWithValue("@cat", 21);
                        cmd1.Parameters.AddWithValue("@valor", opcion);
                        cmd1.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        System.IO.File.AppendAllText(pathString, e.ToString() + Environment.NewLine);
                        System.IO.File.AppendAllText(pathString, dbRow.ToString() + Environment.NewLine);
                        ////MessageBox.Show(e.ToString());
                    }
                }
                else
                {
                    try
                    {
                        int numero = Convert.ToInt32(num);
                        string opcion = Convert.ToString(checaOpcion(mySqlConnection, dbRow, 21, "ORIENTA"));
                        var cmd1 = new SqlCommand();
                        cmd1.Parameters.Clear();
                        cmd1.Connection = mySqlConnection;
                        cmd1.CommandType = CommandType.Text;
                        cmd1.CommandText = @"INSERT INTO [Tomin].[TominPredial].[ColindanciaCatalogo_Log] ([Id_Action],[Id_User],[Id_Date],[Clave],[Num],[Id_Catalogo],[Valor])"
                                            + " VALUES (@accion, @usuario, @fecha, @clave, @num, @cat,@valor)";
                        cmd1.Parameters.AddWithValue("@accion", 1);
                        cmd1.Parameters.AddWithValue("@usuario", "Admin");
                        cmd1.Parameters.AddWithValue("@fecha", DateTime.Now);
                        cmd1.Parameters.AddWithValue("@clave", dbRow["CPRED"].ToString().Trim());
                        cmd1.Parameters.AddWithValue("@num", numero + 1);
                        cmd1.Parameters.AddWithValue("@cat", 21);
                        cmd1.Parameters.AddWithValue("@valor", opcion);
                        cmd1.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        System.IO.File.AppendAllText(pathString, e.ToString() + Environment.NewLine);
                        System.IO.File.AppendAllText(pathString, dbRow.ToString() + Environment.NewLine);
                        //MessageBox.Show(e.ToString());
                    }
                }
            }
            catch (Exception e)
            {
                System.IO.File.AppendAllText(pathString, e.ToString() + Environment.NewLine);
                System.IO.File.AppendAllText(pathString, dbRow.ToString() + Environment.NewLine);
                MessageBox.Show(e.ToString());
            }

        }

        private void insertaColinCata(SqlConnection mySqlConnection, DataRow dbRow, string buena)
        {
            try
            {
                var cmd = new SqlCommand();
                cmd.Parameters.Clear();
                cmd.Connection = mySqlConnection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"select MAX(Num) from Tomin.TominPredial.ColindanciaCatalogo where Clave = @clave";
                cmd.Parameters.AddWithValue("@clave", buena);
                var num = cmd.ExecuteScalar();

                if (num.Equals(DBNull.Value))
                {
                    try
                    {
                        string opcion = Convert.ToString(checaOpcion(mySqlConnection, dbRow, 21, "ORIENTA"));
                        var cmd1 = new SqlCommand();
                        cmd1.Parameters.Clear();
                        cmd1.Connection = mySqlConnection;
                        cmd1.CommandType = CommandType.Text;
                        cmd1.CommandText = @"INSERT INTO [Tomin].[TominPredial].[ColindanciaCatalogo] ([Clave],[Num],[Id_Catalogo],[Valor])"
                                            + " VALUES (@clave, @num, @cat,@valor)";
                        cmd1.Parameters.AddWithValue("@clave", buena);
                        cmd1.Parameters.AddWithValue("@num", 1);
                        cmd1.Parameters.AddWithValue("@cat", 21);
                        cmd1.Parameters.AddWithValue("@valor", opcion);
                        cmd1.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        System.IO.File.AppendAllText(pathString, e.ToString() + Environment.NewLine);
                        System.IO.File.AppendAllText(pathString, dbRow.ToString() + Environment.NewLine);
                        //MessageBox.Show(e.ToString());
                    }
                }
                else
                {
                    try
                    {
                        string opcion = Convert.ToString(checaOpcion(mySqlConnection, dbRow, 21, "ORIENTA"));
                        int numero = Convert.ToInt32(num);
                        var cmd1 = new SqlCommand();
                        cmd1.Parameters.Clear();
                        cmd1.Connection = mySqlConnection;
                        cmd1.CommandType = CommandType.Text;
                        cmd1.CommandText = @"INSERT INTO [Tomin].[TominPredial].[ColindanciaCatalogo] ([Clave],[Num],[Id_Catalogo],[Valor])"
                                            + " VALUES (@clave, @num, @cat,@valor)";
                        cmd1.Parameters.AddWithValue("@clave", buena);
                        cmd1.Parameters.AddWithValue("@num", numero + 1);
                        cmd1.Parameters.AddWithValue("@cat", 21);
                        cmd1.Parameters.AddWithValue("@valor", opcion);
                        cmd1.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        System.IO.File.AppendAllText(pathString, e.ToString() + Environment.NewLine);
                        System.IO.File.AppendAllText(pathString, dbRow.ToString() + Environment.NewLine);
                        //MessageBox.Show(e.ToString());
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

        }

        private Object checaOpcion(SqlConnection mySqlConnection, DataRow dbRow, int op, string opcion)
        {
            try
            {
                var cmd = new SqlCommand();
                cmd.Parameters.Clear();
                cmd.Connection = mySqlConnection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"select Num from Tomin.TominPredial.Opcion where Nombre = @opcion and Id_Catalogo = @op";
                cmd.Parameters.AddWithValue("@opcion", dbRow[opcion].ToString().Trim());
                cmd.Parameters.AddWithValue("@op", op);
                return cmd.ExecuteScalar();
            }
            catch (Exception e)
            {
                System.IO.File.AppendAllText(pathString, e.ToString() + Environment.NewLine);
                System.IO.File.AppendAllText(pathString, dbRow.ToString() + Environment.NewLine);
                return 0;
            }
        }

        private void insertaColindanciasLog(SqlConnection mySqlConnection, DataRow dbRow)
        {
            //MessageBox.Show("Entro");
            try
            {
                var cmd = new SqlCommand();
                cmd.Parameters.Clear();
                cmd.Connection = mySqlConnection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"select MAX(Num) from Tomin.TominPredial.Colindancia_Log Where Clave = @Clave";
                cmd.Parameters.AddWithValue("@Clave", dbRow["CPRED"].ToString().Trim());
                var num = cmd.ExecuteScalar();

                //MessageBox.Show("" + dbRow["CPRED"].ToString().Trim());
                if (num.Equals(DBNull.Value))
                {
                    //MesageBox.Show("Cero");
                    try
                    {
                        var cmd1 = new SqlCommand();
                        cmd1.Parameters.Clear();
                        cmd1.Connection = mySqlConnection;
                        cmd1.CommandType = CommandType.Text;
                        cmd1.CommandText = @"INSERT INTO [Tomin].[TominPredial].[Colindancia_Log] ([Id_Action],[Id_User],[Id_Date],[Clave],[Num],[Medida],[Notas])"
                                            + " VALUES (@accion, @user, @fecha,@Clave,@Num,@Medida,@Notas)";
                        cmd1.Parameters.AddWithValue("@accion", 1);
                        cmd1.Parameters.AddWithValue("@user", "Admin");
                        cmd1.Parameters.AddWithValue("@fecha", DateTime.Now);
                        cmd1.Parameters.AddWithValue("@Clave", dbRow["CPRED"].ToString().Trim());
                        cmd1.Parameters.AddWithValue("@Num", 1);
                        cmd1.Parameters.AddWithValue("@Medida", dbRow["MEDIDA"].ToString().Trim());
                        cmd1.Parameters.AddWithValue("@Notas", dbRow["COL_NOTAS"].ToString().Trim());
                        cmd1.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        System.IO.File.AppendAllText(pathString, e.ToString() + Environment.NewLine);
                        System.IO.File.AppendAllText(pathString, dbRow.ToString() + Environment.NewLine);
                        //MessageBox.Show(e.ToString());
                    }
                }
                else
                {
                    //MessageBox.Show("No cero");
                    int numero = Convert.ToInt32(num);
                    try
                    {
                        var cmd1 = new SqlCommand();
                        cmd1.Parameters.Clear();
                        cmd1.Connection = mySqlConnection;
                        cmd1.CommandType = CommandType.Text;
                        cmd1.CommandText = @"INSERT INTO [Tomin].[TominPredial].[Colindancia_Log] ([Id_Action],[Id_User],[Id_Date],[Clave],[Num],[Medida],[Notas])"
                                            + " VALUES (@accion, @user, @fecha,@Clave,@Num,@Medida,@Notas)";
                        cmd1.Parameters.AddWithValue("@accion", 1);
                        cmd1.Parameters.AddWithValue("@user", "Admin");
                        cmd1.Parameters.AddWithValue("@fecha", DateTime.Now);
                        cmd1.Parameters.AddWithValue("@Clave", dbRow["CPRED"].ToString().Trim());
                        cmd1.Parameters.AddWithValue("@Num", numero + 1);
                        cmd1.Parameters.AddWithValue("@Medida", dbRow["MEDIDA"].ToString().Trim());
                        cmd1.Parameters.AddWithValue("@Notas", dbRow["COL_NOTAS"].ToString().Trim());
                        cmd1.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        System.IO.File.AppendAllText(pathString, e.ToString() + Environment.NewLine);
                        System.IO.File.AppendAllText(pathString, dbRow.ToString() + Environment.NewLine);
                        //MessageBox.Show(e.ToString());
                    }
                }
            }
            catch (Exception e)
            {
                System.IO.File.AppendAllText(pathString, e.ToString() + Environment.NewLine);
                System.IO.File.AppendAllText(pathString, dbRow.ToString() + Environment.NewLine);
                MessageBox.Show(e.ToString());

            }

        }

        private void insertaColindancias(SqlConnection mySqlConnection, DataRow dbRow, string buena)
        {

            //MessageBox.Show("Entro");

            try
            {

                var cmd = new SqlCommand();
                cmd.Parameters.Clear();
                cmd.Connection = mySqlConnection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"select MAX(Num) from Tomin.TominPredial.Colindancia Where Clave = @Clave";
                cmd.Parameters.AddWithValue("@Clave", buena);
                var num = cmd.ExecuteScalar();

                //MessageBox.Show("" + dbRow["CPRED"].ToString().Trim());
                if (num.Equals(DBNull.Value))
                {

                    //MesageBox.Show("Cero");
                    try
                    {
                        var cmd1 = new SqlCommand();
                        cmd1.Parameters.Clear();
                        cmd1.Connection = mySqlConnection;
                        cmd1.CommandType = CommandType.Text;
                        cmd1.CommandText = @"INSERT INTO [Tomin].[TominPredial].[Colindancia] ([Clave],[Num],[Medida],[Notas])"
                                            + " VALUES (@Clave,@Num,@Medida,@Notas)";
                        cmd1.Parameters.AddWithValue("@Clave", buena);
                        cmd1.Parameters.AddWithValue("@Num", 1);
                        cmd1.Parameters.AddWithValue("@Medida", dbRow["MEDIDA"].ToString().Trim());
                        cmd1.Parameters.AddWithValue("@Notas", dbRow["COL_NOTAS"].ToString().Trim());
                        cmd1.ExecuteNonQuery();
                    }
                    catch (SqlException sex)
                    {
                        if (sex.Number == 547)
                        {
                            //System.IO.File.AppendAllText(pathString, dbRow["CPRED"].ToString().Trim() + Environment.NewLine);
                            //var so = checaPredio(mySqlConnection, dbRow);
                            //string buena = Convert.ToString(checaPredio(mySqlConnection, dbRow));
                        }
                        else
                        {
                            MessageBox.Show(sex.Number.ToString());
                        }
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(dbRow["CPRED"].ToString().Trim());
                        System.IO.File.AppendAllText(pathString, e.ToString() + Environment.NewLine);
                        System.IO.File.AppendAllText(pathString, dbRow["CPRED"].ToString().Trim() + Environment.NewLine);
                        MessageBox.Show(e.ToString());

                    }
                }
                else
                {
                    //MessageBox.Show("No cero");
                    int numero = Convert.ToInt32(num);
                    try
                    {
                        var cmd1 = new SqlCommand();
                        cmd1.Parameters.Clear();
                        cmd1.Connection = mySqlConnection;
                        cmd1.CommandType = CommandType.Text;
                        cmd1.CommandText = @"INSERT INTO [Tomin].[TominPredial].[Colindancia]([Clave],[Num],[Medida],[Notas])"
                                            + " VALUES(@Clave,@Num,@Medida,@Notas)";
                        cmd1.Parameters.AddWithValue("@Clave", buena);
                        cmd1.Parameters.AddWithValue("@Num", numero + 1);
                        cmd1.Parameters.AddWithValue("@Medida", dbRow["MEDIDA"].ToString().Trim());
                        cmd1.Parameters.AddWithValue("@Notas", dbRow["COL_NOTAS"].ToString().Trim());
                        cmd1.ExecuteNonQuery();
                    }
                    catch (SqlException sex)
                    {
                        if (sex.Number == 547)
                        {
                            //System.IO.File.AppendAllText(pathString, dbRow["CPRED"].ToString().Trim() + Environment.NewLine);
                            //var so = checaPredio(mySqlConnection, dbRow);
                            //string buena = Convert.ToString(checaPredio(mySqlConnection, dbRow));
                        }
                        else
                        {
                            MessageBox.Show(sex.Number.ToString());
                        }
                    }
                    catch (Exception e)
                    {
                        System.IO.File.AppendAllText(pathString, e.ToString() + Environment.NewLine);
                        System.IO.File.AppendAllText(pathString, dbRow.ToString() + Environment.NewLine);
                        MessageBox.Show(e.ToString());
                    }
                }

            }
            catch (Exception e)
            {
                System.IO.File.AppendAllText(pathString, e.ToString() + Environment.NewLine);
                System.IO.File.AppendAllText(pathString, dbRow.ToString() + Environment.NewLine);
                MessageBox.Show(e.ToString());

            }

        }

        private void creaVistaPredio(SqlConnection mySqlConnection)
        {
            try
            {
                var cmd1 = new SqlCommand();
                cmd1.Parameters.Clear();
                cmd1.Connection = mySqlConnection;
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = @"create view vwPredial as select Clave, ClaveAnt from Tomin.TominPredial.Predio";
                cmd1.ExecuteNonQuery();
                
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private string checaPredio(SqlConnection mySqlConnection, DataRow dbRow, string donde)
        {
            //MesageBox.Show("Cero");
            try
            {
                var cmd1 = new SqlCommand();
                cmd1.Parameters.Clear();
                cmd1.Connection = mySqlConnection;
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = @"select MAX(Clave) from vwPredial where "+ donde + " = @clave";
                cmd1.Parameters.AddWithValue("@clave", dbRow["CPRED"].ToString().Trim());
                var so = cmd1.ExecuteScalar();
                if (!so.Equals(DBNull.Value))
                {
                    string buena = Convert.ToString(so);
                    return buena;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        private void dataGrid1_Navigate(object sender, NavigateEventArgs ne)
        {

        }

        private void insertaPredioContribuyente(SqlConnection mySqlConnection, DataRow dbRow)
        {
            try
            {
                var cmd = new SqlCommand();
                cmd.Parameters.Clear();
                cmd.Connection = mySqlConnection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"SELECT Max(Id_Entidad) FROM [Tomin].[TominRH].[Entidad] where Id_Entidad = @clave";
                cmd.Parameters.AddWithValue("@clave", dbRow["CUENTA"].ToString().Trim());
                var entidad = cmd.ExecuteScalar();
                if (!entidad.Equals(DBNull.Value))
                {
                    //MessageBox.Show(dbRow["CPRED"].ToString().Trim());
                    try
                    {
                        var cmd1 = new SqlCommand();
                        cmd1.Parameters.Clear();
                        cmd1.Connection = mySqlConnection;
                        cmd1.CommandType = CommandType.Text;
                        cmd1.CommandText = @"INSERT INTO [Tomin].[TominPredial].[PredioContribuyente] ([Cuenta],[Clave],[Relacion])"
                                            + " VALUES (@Cuenta,@Clave, 1) ";
                        cmd1.Parameters.AddWithValue("@Cuenta", dbRow["CUENTA"].ToString().Trim());
                        cmd1.Parameters.AddWithValue("@Clave", dbRow["CPRED"].ToString().Trim());
                        cmd1.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        System.IO.File.AppendAllText(pathString, e.ToString() + Environment.NewLine);
                        System.IO.File.AppendAllText(pathString, dbRow["CUENTA"].ToString().Trim() + " " + dbRow["CPRED"].ToString().Trim() + Environment.NewLine);
                        //MessageBox.Show(e.ToString());

                    }
                }
                else
                {
                    try
                    {
                        var cmd2 = new SqlCommand();
                        cmd2.Parameters.Clear();
                        cmd2.Connection = mySqlConnection;
                        cmd2.CommandType = CommandType.Text;
                        cmd2.CommandText = @"SELECT Id_Entidad FROM [Tomin].[TominRH].[Persona_Dup] where Id_Entidad_Dup = @clave1";
                        cmd2.Parameters.AddWithValue("@clave1", dbRow["CUENTA"].ToString().Trim());
                        var entidad1 = cmd2.ExecuteScalar();
                        string ent1 = entidad1.ToString();
                        //MessageBox.Show(entidad1.ToString());
                        //MessageBox.Show(ent1);
                        try
                        {
                            var cmd1 = new SqlCommand();
                            cmd1.Parameters.Clear();
                            cmd1.Connection = mySqlConnection;
                            cmd1.CommandType = CommandType.Text;
                            cmd1.CommandText = @"INSERT INTO [Tomin].[TominPredial].[PredioContribuyente] ([Cuenta],[Clave],[Relacion])"
                                                + " VALUES (@Cuenta,@Clave, 1) ";
                            cmd1.Parameters.AddWithValue("@Cuenta", ent1);
                            cmd1.Parameters.AddWithValue("@Clave", dbRow["CPRED"].ToString().Trim());
                            cmd1.ExecuteNonQuery();
                        }
                        catch (Exception e)
                        {
                            System.IO.File.AppendAllText(pathString, e.ToString() + Environment.NewLine);
                            System.IO.File.AppendAllText(pathString, ent1 + " " + dbRow["CPRED"].ToString().Trim() + Environment.NewLine);
                            //MessageBox.Show(e.ToString());

                        }
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.ToString());
                    }
                }
            }
            catch
            {

            }
        }

        private void insertaPredioContribuyenteLog(SqlConnection mySqlConnection, DataRow dbRow)
        {
            try
            {
                var cmd = new SqlCommand();
                cmd.Parameters.Clear();
                cmd.Connection = mySqlConnection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"SELECT Max(Id_Entidad) FROM [Tomin].[TominRH].[Entidad] where Id_Entidad = @clave";
                cmd.Parameters.AddWithValue("@clave", dbRow["CUENTA"].ToString().Trim());
                var entidad = cmd.ExecuteScalar();
                if (!entidad.Equals(DBNull.Value))
                {
                    //MessageBox.Show(dbRow["CPRED"].ToString().Trim());
                    try
                    {
                        var cmd1 = new SqlCommand();
                        cmd1.Parameters.Clear();
                        cmd1.Connection = mySqlConnection;
                        cmd1.CommandType = CommandType.Text;
                        cmd1.CommandText = @"INSERT INTO [Tomin].[TominPredial].[PredioContribuyente_Log] ([Id_Action],[Id_User],[Id_Date],[Cuenta],[Clave],[Relacion])"
                                            + " VALUES (@accion, @usuario, @fecha, @Cuenta,@Clave, 1) ";
                        cmd1.Parameters.AddWithValue("@accion", 1);
                        cmd1.Parameters.AddWithValue("@usuario", "Admin");
                        cmd1.Parameters.AddWithValue("@fecha", DateTime.Now);
                        cmd1.Parameters.AddWithValue("@Cuenta", dbRow["CUENTA"].ToString().Trim());
                        cmd1.Parameters.AddWithValue("@Clave", dbRow["CPRED"].ToString().Trim());
                        cmd1.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        System.IO.File.AppendAllText(pathString, e.ToString() + Environment.NewLine);
                        System.IO.File.AppendAllText(pathString, dbRow["CUENTA"].ToString().Trim() + " " + dbRow["CPRED"].ToString().Trim() + Environment.NewLine);
                        MessageBox.Show(e.ToString());

                    }
                }
                else
                {
                    try
                    {
                        var cmd2 = new SqlCommand();
                        cmd2.Parameters.Clear();
                        cmd2.Connection = mySqlConnection;
                        cmd2.CommandType = CommandType.Text;
                        cmd2.CommandText = @"SELECT Id_Entidad FROM [Tomin].[TominRH].[Persona_Dup] where Id_Entidad_Dup = @clave1";
                        cmd2.Parameters.AddWithValue("@clave1", dbRow["CUENTA"].ToString().Trim());
                        var entidad1 = cmd2.ExecuteScalar();
                        string ent1 = entidad1.ToString();
                        //MessageBox.Show(entidad1.ToString());
                        //MessageBox.Show(ent1);
                        try
                        {
                            var cmd1 = new SqlCommand();
                            cmd1.Parameters.Clear();
                            cmd1.Connection = mySqlConnection;
                            cmd1.CommandType = CommandType.Text;
                            cmd1.CommandText = @"INSERT INTO [Tomin].[TominPredial].[PredioContribuyente_Log] ([Id_Action],[Id_User],[Id_Date],[Cuenta],[Clave],[Relacion])"
                                                + " VALUES (@accion, @usuario, @fecha, @Cuenta,@Clave, 1) ";
                            cmd1.Parameters.AddWithValue("@accion", 1);
                            cmd1.Parameters.AddWithValue("@usuario", "Admin");
                            cmd1.Parameters.AddWithValue("@fecha", DateTime.Now);
                            cmd1.Parameters.AddWithValue("@Cuenta", ent1);
                            cmd1.Parameters.AddWithValue("@Clave", dbRow["CPRED"].ToString().Trim());
                            cmd1.ExecuteNonQuery();
                        }
                        catch (Exception e)
                        {
                            System.IO.File.AppendAllText(pathString, e.ToString() + Environment.NewLine);
                            System.IO.File.AppendAllText(pathString, ent1 + " " + dbRow["CPRED"].ToString().Trim() + Environment.NewLine);
                            MessageBox.Show(e.ToString());

                        }
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.ToString());
                    }
                }
            }
            catch
            {

            }
        }

        private void insertaRusticoLog(SqlConnection mySqlConnection, DataRow dbRow, int id_com)
        {
            try
            {
                var cmd1 = new SqlCommand();
                cmd1.Parameters.Clear();
                cmd1.Connection = mySqlConnection;
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = @"INSERT INTO [Tomin].[TominPredial].[Rustico_Log] ([Id_Action],[Id_User],[Id_Date],"
                                    + "[Clave],[Id_Comunidad],[Referencia2]"
                                    + ",[NumHabitantes],[ValorSupRiego],[ValorSupTemporal],[ValorSupAgostadero],[ValorSupSolar]"
                                    + ",[ValorConstruccion])"
                                    + " VALUES (@Id_Action,@Id_User,@Id_Date,@Clave,@Id_Comunidad,@Referencia2,@NumHabitantes,@ValorSupRiego,@ValorSupTemporal,"
                                    + "@ValorSupAgostadero,@ValorSupSolar,@ValorConstruccion) ";
                cmd1.Parameters.AddWithValue("@Id_Action", 1);
                cmd1.Parameters.AddWithValue("@Id_User", "Admin");
                cmd1.Parameters.AddWithValue("@Id_Date", DateTime.Now);
                cmd1.Parameters.AddWithValue("@Clave", dbRow["CPRED"].ToString().Trim());
                cmd1.Parameters.AddWithValue("@Id_Comunidad", id_com);
                cmd1.Parameters.AddWithValue("@Referencia2", dbRow["UBICA"].ToString().Trim());
                cmd1.Parameters.AddWithValue("@NumHabitantes", dbRow["RE_NUMHAB"].ToString().Trim());
                cmd1.Parameters.AddWithValue("@ValorSupRiego", dbRow["R_RIESUP"].ToString().Trim());
                cmd1.Parameters.AddWithValue("@ValorSupTemporal", dbRow["R_TEMSUP"].ToString().Trim());
                cmd1.Parameters.AddWithValue("@ValorSupAgostadero", dbRow["R_AGOSUP"].ToString().Trim());
                cmd1.Parameters.AddWithValue("@ValorSupSolar", dbRow["R_SOLSUP"].ToString().Trim());
                cmd1.Parameters.AddWithValue("@ValorConstruccion", dbRow["R_VALCATC"].ToString().Trim());
                cmd1.ExecuteNonQuery();
            }
            catch (SqlException sex)
            {
                if (sex.Number == 2627)
                {
                    System.IO.File.AppendAllText(pathString, "Rustico_Log repetido: " + dbRow["CPRED"].ToString().Trim() + Environment.NewLine);
                }
            }
            catch (Exception e)
            {
                System.IO.File.AppendAllText(pathString, e.ToString() + Environment.NewLine);
                System.IO.File.AppendAllText(pathString, dbRow.ToString() + Environment.NewLine);
                //MessageBox.Show(e.ToString());

            }
        }

        private void insertaRustico(SqlConnection mySqlConnection, DataRow dbRow, int id_com)
        {
            try
            {
                double riego;
                double temp;
                double agost;
                double sol;
                double cons;

                if (!Double.TryParse(dbRow["R_RIESUP"].ToString().Trim(), out riego))
                {
                    riego = 0.0; // or alert, or whatever.
                }
                if (!Double.TryParse(dbRow["R_TEMSUP"].ToString().Trim(), out temp))
                {
                    temp = 0.0; // or alert, or whatever.
                }
                if (!Double.TryParse(dbRow["R_AGOSUP"].ToString().Trim(), out agost))
                {
                    agost = 0.0; // or alert, or whatever.
                }
                if (!Double.TryParse(dbRow["R_SOLSUP"].ToString().Trim(), out sol))
                {
                    sol = 0.0; // or alert, or whatever.
                }
                if (!Double.TryParse(dbRow["R_VALCATC"].ToString().Trim(), out cons))
                {
                    cons = 0.0; // or alert, or whatever.
                }
                var cmd1 = new SqlCommand();
                cmd1.Parameters.Clear();
                cmd1.Connection = mySqlConnection;
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = @"INSERT INTO [Tomin].[TominPredial].[Rustico] ([Clave],[Id_Comunidad],[Referencia2]"
                                    + ",[NumHabitantes],[ValorSupRiego],[ValorSupTemporal],[ValorSupAgostadero],[ValorSupSolar]"
                                    + ",[ValorConstruccion])"
                                    + " VALUES (@Clave,@Id_Comunidad,@Referencia2,@NumHabitantes,@ValorSupRiego,@ValorSupTemporal,"
                                    + "@ValorSupAgostadero,@ValorSupSolar,@ValorConstruccion) ";
                cmd1.Parameters.AddWithValue("@Clave", dbRow["CPRED"].ToString().Trim());
                cmd1.Parameters.AddWithValue("@Id_Comunidad", id_com);
                cmd1.Parameters.AddWithValue("@Referencia2", dbRow["UBICA"].ToString().Trim());
                cmd1.Parameters.AddWithValue("@NumHabitantes", dbRow["RE_NUMHAB"].ToString().Trim());
                cmd1.Parameters.AddWithValue("@ValorSupRiego", riego);
                cmd1.Parameters.AddWithValue("@ValorSupTemporal", temp);
                cmd1.Parameters.AddWithValue("@ValorSupAgostadero", agost);
                cmd1.Parameters.AddWithValue("@ValorSupSolar", sol);
                cmd1.Parameters.AddWithValue("@ValorConstruccion", cons);
                cmd1.ExecuteNonQuery();
            }
            catch (SqlException sex)
            {
                MessageBox.Show(sex.Number.ToString());
                MessageBox.Show(sex.ToString());
                if (sex.Number == 2627)
                {
                    System.IO.File.AppendAllText(pathString, "Rustico repetido: " + dbRow["CPRED"].ToString().Trim() + Environment.NewLine);
                }
            }
            catch (Exception e)
            {
                System.IO.File.AppendAllText(pathString, e.ToString() + Environment.NewLine);
                System.IO.File.AppendAllText(pathString, dbRow.ToString() + Environment.NewLine);
                MessageBox.Show(e.ToString());

            }
        }

        private Object checaComDuplicados(SqlConnection mySqlConnection, String nombre, int id_pob, int contador)
        {
            nombre = nombre.ToUpper();
            nombre = nombre.Trim();
            var cmd = new SqlCommand();
            cmd.Parameters.Clear();
            cmd.Connection = mySqlConnection;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT Id_Comunidad FROM TominPredial.Comunidad WHERE Nombre = @Nombre and Id_Poblacion = @id_pob";
            cmd.Parameters.AddWithValue("@Nombre", nombre);
            cmd.Parameters.AddWithValue("@id_pob", id_pob);
            try
            {

                if (cmd.ExecuteScalar() == null)
                {

                    var cmd1 = new SqlCommand();
                    cmd1.Parameters.Clear();
                    cmd1.Connection = mySqlConnection;
                    cmd1.CommandType = CommandType.Text;
                    cmd1.CommandText = @"INSERT INTO [Tomin].[TominPredial].[Comunidad]([Nombre],[Id_Poblacion]"
                        + ",[Id_User],[Id_Date])"
                        + " VALUES(@Nombre,@Id_Poblacion,@Id_User,@Id_Date)";
                    cmd1.Parameters.AddWithValue("@Nombre", nombre);
                    cmd1.Parameters.AddWithValue("@Id_Poblacion", id_pob);
                    cmd1.Parameters.AddWithValue("@Id_User", "Admin");
                    cmd1.Parameters.AddWithValue("@Id_Date", DateTime.Now);
                    cmd1.ExecuteNonQuery();

                    var cmdID = new SqlCommand();
                    cmdID.Connection = mySqlConnection;
                    cmdID.CommandType = CommandType.Text;
                    cmdID.CommandText = @"SELECT MAX(Id_Comunidad) FROM TominPredial.Comunidad";
                    return cmdID.ExecuteScalar();
                }
                else
                {
                    return cmd.ExecuteScalar();
                }
            }
            catch (Exception e)
            {
                System.IO.File.AppendAllText(pathString, e.ToString() + Environment.NewLine);
                System.IO.File.AppendAllText(pathString, nombre + Environment.NewLine);
                //MessageBox.Show(e.ToString());
                return 0;

            }
        }

        private void insertaUrbanoLog(SqlConnection mySqlConnection, DataRow dbRow, int id_calle)
        {
            try
            {
                double terre;
                double cons;

                if (!Double.TryParse(dbRow["U_VALCATT"].ToString().Trim(), out terre))
                {
                    terre = 0.0; // or alert, or whatever.
                }
                if (!Double.TryParse(dbRow["U_VALCATC"].ToString().Trim(), out cons))
                {
                    cons = 0.0; // or alert, or whatever.
                }
                var cmd1 = new SqlCommand();
                cmd1.Parameters.Clear();
                cmd1.Connection = mySqlConnection;
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = @"INSERT INTO [Tomin].[TominPredial].[Urbano_Log] ([Id_Action],[Id_User],[Id_Date],[Clave], "
                                    + "[Id_Calle],[Frente],[Fondo],[ValorTerreno],[ValorConstruccion]) "
                                    + " VALUES (@accion,@usuario,@fecha,@Clave,@Id_Calle,@frente,@fondo,@valTerreno,@valCons) ";
                cmd1.Parameters.AddWithValue("@accion", 1);
                cmd1.Parameters.AddWithValue("@usuario", "Admin");
                cmd1.Parameters.AddWithValue("@fecha", DateTime.Now);
                cmd1.Parameters.AddWithValue("@Clave", dbRow["CPRED"].ToString().Trim());
                cmd1.Parameters.AddWithValue("@Id_Calle", id_calle);
                cmd1.Parameters.AddWithValue("@frente", dbRow["UE_FRENTE"].ToString().Trim());
                cmd1.Parameters.AddWithValue("@fondo", dbRow["UE_FONDO"].ToString().Trim());
                cmd1.Parameters.AddWithValue("@valTerreno", terre);
                cmd1.Parameters.AddWithValue("@valCons", cons);
                cmd1.ExecuteNonQuery();
            }
            catch (SqlException sex)
            {
                if (sex.Number == 2627)
                {
                    System.IO.File.AppendAllText(pathString, "Urbano_Log repetido: " + dbRow["CPRED"].ToString().Trim() + Environment.NewLine);
                }
            }
            catch (Exception e)
            {
                System.IO.File.AppendAllText(pathString, e.ToString() + Environment.NewLine);
                System.IO.File.AppendAllText(pathString, dbRow.ToString() + Environment.NewLine);
                //MessageBox.Show(e.ToString());

            }
        }

        private void insertaUrbano(SqlConnection mySqlConnection, DataRow dbRow, int id_calle)
        {
            try
            {
                double terre;
                double cons;

                if (!Double.TryParse(dbRow["U_VALCATT"].ToString().Trim(), out terre))
                {
                    terre = 0.0; // or alert, or whatever.
                }
                if (!Double.TryParse(dbRow["U_VALCATC"].ToString().Trim(), out cons))
                {
                    cons = 0.0; // or alert, or whatever.
                }
                var cmd1 = new SqlCommand();
                cmd1.Parameters.Clear();
                cmd1.Connection = mySqlConnection;
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = @"INSERT INTO [Tomin].[TominPredial].[Urbano]([Clave],[Id_Calle],[Frente],[Fondo]"
                                    + ",[ValorTerreno],[ValorConstruccion])"
                                    + " VALUES(@Clave,@Id_Calle,@frente,@fondo,@valTerreno,@valCons)";
                cmd1.Parameters.AddWithValue("@Clave", dbRow["CPRED"].ToString().Trim());
                cmd1.Parameters.AddWithValue("@Id_Calle", id_calle);
                cmd1.Parameters.AddWithValue("@frente", dbRow["UE_FRENTE"].ToString().Trim());
                cmd1.Parameters.AddWithValue("@fondo", dbRow["UE_FONDO"].ToString().Trim());
                cmd1.Parameters.AddWithValue("@valTerreno", terre);
                cmd1.Parameters.AddWithValue("@valCons", cons);
                cmd1.ExecuteNonQuery();
            }
            catch (SqlException sex)
            {
                MessageBox.Show(sex.ToString());
                MessageBox.Show(sex.Number.ToString());
                if (sex.Number == 2627)
                {
                    System.IO.File.AppendAllText(pathString, "Urbano repetido: " + dbRow["CPRED"].ToString().Trim() + Environment.NewLine);
                }
            }
            catch (Exception e)
            {
                System.IO.File.AppendAllText(pathString, e.ToString() + Environment.NewLine);
                System.IO.File.AppendAllText(pathString, dbRow.ToString() + Environment.NewLine);
                MessageBox.Show(e.ToString());

            }
        }

        private Object insertaCallesPredio(SqlConnection mySqlConnection, String nombreCalle, int id_col)
        {
            var cmd = new SqlCommand();
            cmd.Parameters.Clear();
            cmd.Connection = mySqlConnection;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select Id_Calle FROM TominPredial.Calle "
                                + " WHERE Nombre = @NombreCalle and Id_Colonia = @id_col";
            cmd.Parameters.AddWithValue("@NombreCalle", nombreCalle);
            cmd.Parameters.AddWithValue("@id_col", id_col);
            try
            {

                if (cmd.ExecuteScalar() == null)
                {

                    var cmd1 = new SqlCommand();
                    cmd1.Parameters.Clear();
                    cmd1.Connection = mySqlConnection;
                    cmd1.CommandType = CommandType.Text;
                    cmd1.CommandText = @"INSERT INTO [Tomin].[TominPredial].[Calle]([Nombre],[Id_Colonia]"
                        + ",[Id_User],[Id_Date])"
                        + " VALUES(@Nombre,@Id_Colonia,@Id_User,@Id_Date)";
                    cmd1.Parameters.AddWithValue("@Nombre", nombreCalle);
                    cmd1.Parameters.AddWithValue("@Id_Colonia", id_col);
                    cmd1.Parameters.AddWithValue("@Id_User", "Admin");
                    cmd1.Parameters.AddWithValue("@Id_Date", DateTime.Now);
                    cmd1.ExecuteNonQuery();

                    var cmdID = new SqlCommand();
                    cmdID.Connection = mySqlConnection;
                    cmdID.CommandType = CommandType.Text;
                    cmdID.CommandText = @"SELECT IDENT_CURRENT('TominPredial.Calle')";
                    return cmdID.ExecuteScalar();
                }
                else
                {
                    return cmd.ExecuteScalar();
                }

            }
            catch (Exception e)
            {
                System.IO.File.AppendAllText(pathString, e.ToString() + Environment.NewLine);
                System.IO.File.AppendAllText(pathString, nombreCalle + Environment.NewLine);
                //MessageBox.Show(e.ToString());
                return 0;

            }
        }

        private string checaDomNumero(String dom)
        {
            string[] domicilioSeparado = dom.Split(' ');
            if (domicilioSeparado.Length > 1)
            {
                if (Regex.IsMatch(domicilioSeparado.Last(), @"\d|S\/N"))
                {
                    String domicilioSinNum = "";
                    for (int z = 0; z < domicilioSeparado.Length - 1; z++)
                    {
                        domicilioSinNum += " " + domicilioSeparado[z];
                    }
                    return domicilioSinNum;
                }
                else
                {
                    return dom;
                }

            }
            else
            {
                return "";
            }
        }

        private Object checaColDuplicados(SqlConnection mySqlConnection, String nombre, int id_pob, int contador)
        {
            nombre = nombre.ToUpper();
            nombre = nombre.Replace("COLONIA", "");
            nombre = nombre.Replace("FRACCIONAMIENTO", "");
            nombre = nombre.Replace("FRACC", "");
            nombre = nombre.Replace("FRACC.", "");
            nombre = nombre.Replace("COL", "");
            nombre = nombre.Replace("COL.", "");
            nombre = nombre.Trim();
            var cmd = new SqlCommand();
            cmd.Parameters.Clear();
            cmd.Connection = mySqlConnection;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT Id_Colonia FROM TominPredial.Colonia WHERE Nombre = @Nombre and Id_Poblacion = @id_pob";
            cmd.Parameters.AddWithValue("@Nombre", nombre);
            cmd.Parameters.AddWithValue("@id_pob", id_pob);
            try
            {

                if (cmd.ExecuteScalar() == null)
                {

                    var cmd1 = new SqlCommand();
                    cmd1.Parameters.Clear();
                    cmd1.Connection = mySqlConnection;
                    cmd1.CommandType = CommandType.Text;
                    cmd1.CommandText = @"INSERT INTO [Tomin].[TominPredial].[Colonia]([Nombre],[Id_Poblacion]"
                        + ",[Id_User],[Id_Date])"
                        + " VALUES(@Nombre,@Id_Poblacion,@Id_User,@Id_Date)";
                    cmd1.Parameters.AddWithValue("@Nombre", nombre);
                    cmd1.Parameters.AddWithValue("@Id_Poblacion", id_pob);
                    cmd1.Parameters.AddWithValue("@Id_User", "Admin");
                    cmd1.Parameters.AddWithValue("@Id_Date", DateTime.Now);
                    cmd1.ExecuteNonQuery();

                    var cmdID = new SqlCommand();
                    cmdID.Connection = mySqlConnection;
                    cmdID.CommandType = CommandType.Text;
                    cmdID.CommandText = @"SELECT Id_Colonia FROM TominPredial.Colonia WHERE Id_Colonia = @@Identity";
                    return cmdID.ExecuteScalar();
                }
                else
                {
                    return cmd.ExecuteScalar();
                }
            }
            catch (Exception e)
            {
                System.IO.File.AppendAllText(pathString, e.ToString() + Environment.NewLine);
                System.IO.File.AppendAllText(pathString, nombre + Environment.NewLine);
                // MessageBox.Show(e.ToString());
                return 0;

            }
        }

        private void insertaPredioLog(SqlConnection mySqlConnection, DataRow dbRow, string tipo)
        {
            try
            {

                double refe;
                double terre;
                double fact;
                double cat;
                double fis;

                if (!Double.TryParse(dbRow["REF_ENTRE1"].ToString().Trim(), out refe))
                {
                    refe = 0.0; // or alert, or whatever.
                }
                if (!Double.TryParse(dbRow["U_TERRENO"].ToString().Trim(), out terre))
                {
                    terre = 0.0; // or alert, or whatever.
                }
                if (!Double.TryParse(dbRow["DEM_FACTOR"].ToString().Trim(), out fact))
                {
                    fact = 0.0; // or alert, or whatever.
                }
                if (!Double.TryParse(dbRow["VAL_CAT"].ToString().Trim(), out cat))
                {
                    cat = 0.0; // or alert, or whatever.
                }
                if (!Double.TryParse(dbRow["VAL_FIS"].ToString().Trim(), out fis))
                {
                    fis = 0.0; // or alert, or whatever.
                }
                var cmdPredio = new SqlCommand();
                cmdPredio.Parameters.Clear();
                cmdPredio.Connection = mySqlConnection;
                cmdPredio.CommandType = CommandType.Text;
                cmdPredio.CommandText = @"INSERT INTO [Tomin].[TominPredial].[Predio_Log]"
                    + "([Id_Action],[Id_User],[Id_Date],[Clave],[Id_SubTipoPredio],[NumeroExt],[Referencia1],[EstatusIP],[Superficie],"
                    + "[ClaveAnt],[Escritura],[FactorDemerito],[NotaDemerito],[ValorCatastral],[ValorFiscal],[ValorAvaluo])"
                    + " VALUES"
                    + "(@Id_Action,@Id_User,@Id_Date,@cvePredio,@subPredio,@numExt,@referencia1,@estatusIP,@superficie,@cveAnt,@escritura,"
                    + "@factDemerito,@notaDemerito,@valCatastral,@valorFiscal, 0)";
                cmdPredio.Parameters.AddWithValue("@Id_Action", 1);
                cmdPredio.Parameters.AddWithValue("@Id_User", "Admin");
                cmdPredio.Parameters.AddWithValue("@Id_Date", DateTime.Now);
                cmdPredio.Parameters.AddWithValue("@cvePredio", dbRow["CPRED"].ToString().Trim());
                cmdPredio.Parameters.AddWithValue("@subPredio", tipo);
                cmdPredio.Parameters.AddWithValue("@numExt", dbRow["NUMEROEXT"].ToString().Trim());
                cmdPredio.Parameters.AddWithValue("@referencia1", refe);
                cmdPredio.Parameters.AddWithValue("@estatusIP", "N");
                cmdPredio.Parameters.AddWithValue("@superficie", terre);
                cmdPredio.Parameters.AddWithValue("@cveAnt", dbRow["CPREDANT"].ToString().Trim());
                cmdPredio.Parameters.AddWithValue("@escritura", dbRow["ESCRITURA"].ToString().Trim());
                cmdPredio.Parameters.AddWithValue("@factDemerito", fact);
                cmdPredio.Parameters.AddWithValue("@notaDemerito", dbRow["DEM_NOTAS"].ToString().Trim());
                cmdPredio.Parameters.AddWithValue("@valCatastral", cat);
                cmdPredio.Parameters.AddWithValue("@valorFiscal", fis);
                cmdPredio.ExecuteNonQuery();
            }
            catch (SqlException sex)
            {
                if (sex.Number == 2627)
                {
                    System.IO.File.AppendAllText(pathString, "Predio_Log repetido: " + dbRow["CPRED"].ToString().Trim() + Environment.NewLine);
                }
            }
            catch (Exception e)
            {
                System.IO.File.AppendAllText(pathString, e.ToString() + Environment.NewLine);
                System.IO.File.AppendAllText(pathString, dbRow.ToString() + Environment.NewLine);
                //MessageBox.Show("predio  " + e.ToString());
            }
        }

        private bool insertaPredio(SqlConnection mySqlConnection, DataRow dbRow, string tipo)
        {
            try
            {
                double refe;
                double terre;
                double fact;
                double cat;
                double fis;

                if (!Double.TryParse(dbRow["REF_ENTRE1"].ToString().Trim(), out refe))
                {
                    refe = 0.0; // or alert, or whatever.
                }
                if (!Double.TryParse(dbRow["U_TERRENO"].ToString().Trim(), out terre))
                {
                    terre = 0.0; // or alert, or whatever.
                }
                if (!Double.TryParse(dbRow["DEM_FACTOR"].ToString().Trim(), out fact))
                {
                    fact = 0.0; // or alert, or whatever.
                }
                if (!Double.TryParse(dbRow["VAL_CAT"].ToString().Trim(), out cat))
                {
                    cat = 0.0; // or alert, or whatever.
                }
                if (!Double.TryParse(dbRow["VAL_FIS"].ToString().Trim(), out fis))
                {
                    fis = 0.0; // or alert, or whatever.
                }

                var cmdPredio = new SqlCommand();
                cmdPredio.Parameters.Clear();
                cmdPredio.Connection = mySqlConnection;
                cmdPredio.CommandType = CommandType.Text;
                cmdPredio.CommandText = @"INSERT INTO [Tomin].[TominPredial].[Predio]"
                    + "([Clave],[Id_SubTipoPredio],[NumeroExt],[Referencia1],[EstatusIP],[Superficie],"
                    + "[ClaveAnt],[Escritura],[FactorDemerito],[NotaDemerito],[ValorCatastral],[ValorFiscal],[ValorAvaluo])"
                    + " VALUES"
                    + "(@cvePredio,@subPredio,@numExt,@referencia1,@estatusIP,@superficie,@cveAnt,@escritura,"
                    + "@factDemerito,@notaDemerito,@valCatastral,@valorFiscal,0)";
                cmdPredio.Parameters.AddWithValue("@cvePredio", dbRow["CPRED"].ToString().Trim());
                cmdPredio.Parameters.AddWithValue("@subPredio", tipo);
                cmdPredio.Parameters.AddWithValue("@numExt", dbRow["NUMEROEXT"].ToString().Trim());
                cmdPredio.Parameters.AddWithValue("@referencia1", refe);
                cmdPredio.Parameters.AddWithValue("@estatusIP", "N");
                cmdPredio.Parameters.AddWithValue("@superficie", terre);
                cmdPredio.Parameters.AddWithValue("@cveAnt", dbRow["CPREDANT"].ToString().Trim());
                cmdPredio.Parameters.AddWithValue("@escritura", dbRow["ESCRITURA"].ToString().Trim());
                cmdPredio.Parameters.AddWithValue("@factDemerito", fact);
                cmdPredio.Parameters.AddWithValue("@notaDemerito", dbRow["DEM_NOTAS"].ToString().Trim());
                cmdPredio.Parameters.AddWithValue("@valCatastral", cat);
                cmdPredio.Parameters.AddWithValue("@valorFiscal", fis);
                cmdPredio.ExecuteNonQuery();
                return true;
            }
            catch (SqlException sex)
            {
                if (sex.Number == 2627)
                {
                    System.IO.File.AppendAllText(pathString, "Predio repetido: " + dbRow["CPRED"].ToString().Trim() + Environment.NewLine);
                }
                else
                {
                    MessageBox.Show(dbRow["REF_ENTRE1"].ToString().Trim());
                    MessageBox.Show(dbRow["U_TERRENO"].ToString().Trim());
                    MessageBox.Show(dbRow["DEM_FACTOR"].ToString().Trim());
                    MessageBox.Show(dbRow["DEM_NOTAS"].ToString().Trim());
                    MessageBox.Show(dbRow["VAL_CAT"].ToString().Trim());
                    MessageBox.Show(dbRow["VAL_FIS"].ToString().Trim());
                    MessageBox.Show(dbRow["CPRED"].ToString().Trim() + sex.ToString());
                    MessageBox.Show(sex.Number.ToString());
                }
                return false;
            }
            catch (Exception e)
            {
                System.IO.File.AppendAllText(pathString, e.ToString() + Environment.NewLine);
                System.IO.File.AppendAllText(pathString, dbRow["CPRED"].ToString().Trim() + Environment.NewLine);

                MessageBox.Show("predio  " + e.ToString());
                return false;
            }
        }

        private bool checaDuplicados(String nombre, SqlConnection mySqlConnection, String id_rep)
        {

            var cmd = new SqlCommand();
            cmd.Parameters.Clear();
            cmd.Connection = mySqlConnection;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT Id_Entidad FROM TominRH.Entidad WHERE Nombre = @Nombre";
            cmd.Parameters.AddWithValue("@Nombre", nombre);
            try
            {
                if (cmd.ExecuteScalar() != null)
                {
                    var cmd1 = new SqlCommand();
                    cmd1.Parameters.Clear();
                    cmd1.Connection = mySqlConnection;
                    cmd1.CommandType = CommandType.Text;
                    cmd1.CommandText = @"INSERT INTO [Tomin].[TominRH].[Persona_Dup] ([Id_Entidad],[Id_Entidad_Dup]) Values (@Buena, @Mala)";
                    cmd1.Parameters.AddWithValue("@Buena", cmd.ExecuteScalar().ToString().Trim());
                    cmd1.Parameters.AddWithValue("@Mala", id_rep.Trim());
                    cmd1.ExecuteNonQuery();
                    System.IO.File.AppendAllText(pathString, "Entidad Repetida: ");
                    System.IO.File.AppendAllText(pathString, id_rep + Environment.NewLine);
                    return false;
                }
                else
                {
                    return true;

                }
            }
            catch (Exception e)
            {
                System.IO.File.AppendAllText(pathString, e.ToString() + Environment.NewLine);
                System.IO.File.AppendAllText(pathString, id_rep + Environment.NewLine);
                //MessageBox.Show(e.ToString());
                return false;

            }
        }
    }
}