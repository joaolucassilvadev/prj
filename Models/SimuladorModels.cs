using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.ComponentModel.DataAnnotations;

namespace prj.Models
{
    public class SimuladorModels
    {


          public  int Id { get; set; }    
        public string cargo { get; set; }   

        public string setor { get; set; }

        public string categoria { get; set; }

        public int leitos { get; set; }
        public string ala { get; set; }

        public int salas { get; set; }

        public int dimensionamento { get; set; }

        public int carga { get; set; }

        public string escala { get; set; }
        
        public int equipemin { get; set; }

        public int rhminimo { get; set; }

        public int rhminimoturno { get; set; }

        public decimal valor { get; set; }

    }
}
