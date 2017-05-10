using DataAccess;
using Model;

namespace BusinessLogic
{
    public class PersonaBusinessLogic
    {
        public int RegistrarPersona(Persona oPersona)
        {
            return new PersonaDataAccess().RegistarPersona(oPersona);
        }

        public ListaPersona ListarPersona()
        {
            return new PersonaDataAccess().ListarPersona();
        }
    }
}
