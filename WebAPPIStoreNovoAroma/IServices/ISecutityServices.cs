namespace WebAPPIStoreNovoAroma.IServices
{
    public class ISecutityServices
    {
        public interface ISecurityServices
        {
            bool ValidateUsuarioCredentials(string usuarioUsuario, string usuarioPassWord, int idRol);
        }
    }
}

