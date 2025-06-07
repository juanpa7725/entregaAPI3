namespace _3er_entregable.DAL.Entities
{
    public class SeederDB
    {
        public readonly DataBaseContext _context;

        public SeederDB(DataBaseContext context)
        {
            _context = context;
        }

        // Crearemos un metodo llamado SeederAsync
        // Este metodo es una especie de MAIN()
        // Este metodo se encargara de crear los datos iniciales de la base de datos

        public async Task SeederAsync()
        {
            //Primero : agregare un metodo propio de EF que hace las veces del comando 'update-database'
            //En otras palabras: un metodo que me creara la BD inmediatamente ponga en ejecucion mi API
            await _context.Database.EnsureCreatedAsync();

            // A partir de aqui vamos creando metodos que se encargaran de crear los datos iniciales de la base de datos
            await PopulateCountriesAsync(); // Llama al método para poblar la tabla de países con datos iniciales

            await _context.SaveChangesAsync(); // Guarda los cambios en la base de datos
        }

    #region Private Methods
    private async Task PopulateCountriesAsync()
        {
            // El metodo Any () me indica si la tabla Countries tiene al menos un dato
            // El metodo Any (!) me indica que no hay absolutamente nada en la tabla Countries
            if (!_context.Countries.Any())
            {
                // Asi creo un objeto pais con sus respectivos estados
                _context.Countries.Add(new Country
                {
                    CreatedDate = DateTime.Now,
                    Name = "Colombia",
                    States = new List<State>
                    {
                        new State
                        {
                            CreatedDate = DateTime.Now,
                            Name = "Antioquia"
                        },
                        new State
                        {
                            CreatedDate = DateTime.Now,
                            Name = "Cundinamarca"
                        }
                    }
                });
                _context.Countries.Add(new Country
                {
                    CreatedDate = DateTime.Now,
                    Name = "Argentina",
                    States = new List<State>
                    {
                        new State
                        {
                            CreatedDate = DateTime.Now,
                            Name = "Buenos Aires"
                        }
                    }
                });
            }
        }

        #endregion


    }
}
