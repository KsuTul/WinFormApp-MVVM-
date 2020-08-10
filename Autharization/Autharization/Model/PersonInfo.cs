using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Authorization.Model
{
    public class PersonInfo
    {
        public string FullName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string SelectedCity { get; set; }
    
    public string Email { get; set; }

        public string Password { get; set; }

        public async Task SaveFile(PersonInfo personInfo)
        {
            var json = JsonSerializer.Serialize<PersonInfo>(personInfo);
            using (StreamWriter file = new StreamWriter(@"C:\Users\Xenia\source\repos\Autharization\Autharization\user.txt", 
                true, System.Text.Encoding.Default))
            {
                await file.WriteLineAsync(json);
            }
        }

        public void ReadFile(string email, string password)
        {
            List<PersonInfo> user = new List<PersonInfo>();
            using (StreamReader sr = new StreamReader(@"C:\Users\Xenia\source\repos\Autharization\Autharization\user.txt"))
            {
                while (sr.ReadLine() != null)
                {
                    user.Add(JsonSerializer.Deserialize<PersonInfo>(sr.ReadLine(), new JsonSerializerOptions()));
                }
            }

            if (user.Any(x => x.Email == email && x.Password == password))
            {
                MessageBox.Show("Пользователь есть");
            }
            else
            {
                var registration = new Registration() { StartPosition = FormStartPosition.CenterParent };
                MessageBox.Show("Никого не видно, присоединяйся к нам!");
                registration.Show();
            }
        }
    }
}