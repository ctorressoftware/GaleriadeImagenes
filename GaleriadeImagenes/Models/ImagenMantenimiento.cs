using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace GaleriadeImagenes.Models
{
    public class ImagenMantenimiento
    {
        private SqlConnection conn;

        private void Conectar()
        {
            string cs = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
            conn = new SqlConnection(cs);
        }

        public List<Imagen> ObtenerTodasLasImagenes()
        {
            Conectar();

            SqlCommand comando = new SqlCommand("SELECT * FROM Imagen", conn);

            conn.Open();
            SqlDataReader sdr = comando.ExecuteReader();

            List<Imagen> imagenes = new List<Imagen>();

            foreach (var img in sdr)
            {
                Imagen imagen = new Imagen
                {
                    Nombre = sdr["Nombre"].ToString(),
                    ImagenUrl = sdr["ImagenUrl"].ToString()
                };

                imagenes.Add(imagen);
            }

            conn.Close();

            return imagenes;
        }
    }
}