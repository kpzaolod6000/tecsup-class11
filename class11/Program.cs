namespace Class11
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Reflection.PortableExecutable;
    using System.Runtime.CompilerServices;
    using static Class11.Program;

    public class Program
    {
        public class Usuario
        {
            protected string Nombre { get; set; }
            private string DNI ;
            public int telefono { get; set; }
            public string email { get; set; }
            public string direccion { get; set; }
            //public string FechaNacimiento { get; set; }

            public Usuario(string nombre, string dni, int _telefono, string _email, string _direccion)
            {
                Nombre = nombre;
                DNI = dni;
                telefono = _telefono;
                email = _email;
                direccion = _direccion;
                Console.WriteLine("Usuario creado");
            }
            public virtual void print()
            {
                //Console.WriteLine($"=== INFORMACIÓN DE USUARIO ===");
                Console.WriteLine($"Nombre: {Nombre}");
                Console.WriteLine($"DNI: {DNI}");
                Console.WriteLine($"Telefono: {telefono}");
                Console.WriteLine($"Email: {email}");
                Console.WriteLine($"Direccion: {direccion}");
            }

            public virtual void notify()
            {
                Console.WriteLine("Notificacion Usuario");
            }
            public string getDni()
            {
                return DNI;
            }
        }
        public class Paciente : Usuario
        {
            public string SeguroSalud { get; set; }

            public Paciente(string nombre, string dni, string seguro, int _telefono, string _email, string _direccion)
                : base(nombre, dni, _telefono, _email, _direccion)
            {
                SeguroSalud = seguro;
                Console.WriteLine("Paciente creado");
            }

            public override void print()
            {
                Console.WriteLine($"=== INFORMACIÓN DE PACIENTE ===");
                base.print();
                Console.WriteLine($"Seguro de Salud: {SeguroSalud}");
            }
            public override void notify()
            {
                Console.WriteLine("Cita Medica sera el dia Martes 12 a las 3:00 pm con el Doctor Perez");
            }
        }
        public class Doctor : Usuario
        {
            public string Especialidad { get; set; }
            //public string universidad { get; set; }
            //List<string> certificaciones { get; set; }
            //public string HorarioInicio { get; set; }
            //public string HorarioFin { get; set; }

            public Doctor(string nombre, string dni, string especialidad, int _telefono, string _email, string _direccion)
                : base(nombre, dni, _telefono, _email, _direccion)
            {
                Especialidad = especialidad;
                Console.WriteLine("Doctor creado");
            }
            public override void print()
            {
                Console.WriteLine($"=== INFORMACIÓN DE DOCTOR ===");
                base.print();
                Console.WriteLine($"Especialidad: {Especialidad}");
            }
            public override void notify()
            {
                Console.WriteLine("Horario de Turno");
                Console.WriteLine("Lunes 9, 9:00 am a 1:00 pm");
                Console.WriteLine("Martes 10, 1:00 pm a 7:00 pm");
                Console.WriteLine("Miercoles 11, 7:00 pm a 7:00 am");
            }
        }

        public class Enfermero : Usuario
        {
            public string universidad { get; set; }
            //List<string> certificaciones { get; set; }
            //public string HorarioInicio { get; set; }
            //public string HorarioFin { get; set; }

            public Enfermero(string nombre, string dni, string _universidad, int _telefono, string _email, string _direccion)
                : base(nombre, dni, _telefono, _email, _direccion)
            {
                universidad = _universidad;
                Console.WriteLine("Enfermero creado");
            }
            public override void print()
            {
                Console.WriteLine($"=== INFORMACIÓN DEL ENFERMERO ===");
                base.print();
                Console.WriteLine($"Universidad: {universidad}");
            }
            public override void notify()
            {
                Console.WriteLine("Horario de Asistencia");
                Console.WriteLine("Lunes 19, 7:00 am a 3:00 pm" + "Con el Doctor Garcia");
                Console.WriteLine("Martes 20, 3:00 pm a 10:00 pm" + "Con la Doctora Polo");
                Console.WriteLine("Miercoles 21, 10:00 pm a 7:00 am" + "Con la Doctora TV Borda");
            }
        }

        static void Main(string[] args)
        {
            //Usuario patient1 = new Paciente("María García", "87654321", "SIS");
            //Usuario patient2 = new Paciente("Manuel Lopez", "78963256", "EsSalud");
            //Usuario doctor1 = new Doctor("Luis Cabrera", "78965236", "Pediatria");
            //Usuario doctor2 = new Doctor("Elena Vargas", "78963256", "Cardiología");

            List<Paciente> pacientes = new List<Paciente>();
            List<Doctor> doctores = new List<Doctor>();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== SISTEMA DE CITAS MEDICAS ===");
                Console.WriteLine("1. Agregar Paciente");
                Console.WriteLine("2. Agregar Doctor");
                Console.WriteLine("3. Mostrar Pacientes");
                Console.WriteLine("4. Mostrar Doctores");
                Console.WriteLine("5. Notificacion de Paciente");
                Console.WriteLine("6. Notificacion de Doctores");
                Console.WriteLine("7. Exit");
                Console.Write("Selecciona una opcion: ");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Console.WriteLine("\n=== AGREGAR NUEVO PACIENTE ===");
                        Console.Write("Ingrese nombre completo: ");
                        string nombrePaciente = Console.ReadLine();
                        Console.Write("Ingrese DNI: ");
                        string dniPaciente = Console.ReadLine();
                        Console.Write("Ingrese tipo de seguro (SIS, EsSalud, Privado): ");
                        string seguro = Console.ReadLine();
                        Console.Write("Ingrese el telefono: ");
                        int telP = int.Parse(Console.ReadLine());
                        Console.Write("Ingrese email: ");
                        string emailP = Console.ReadLine();
                        Console.Write("Ingrese direccion: ");
                        string directionP = Console.ReadLine();

                        Paciente nuevoPaciente = new Paciente(nombrePaciente, dniPaciente, seguro, telP, emailP, directionP);
                        pacientes.Add(nuevoPaciente);
                        Console.WriteLine($"¡Paciente {nombrePaciente} creado exitosamente!");
                        break;

                    case "2":
                        Console.WriteLine("\n=== AGREGAR NUEVO DOCTOR ===");
                        Console.Write("Ingrese nombre completo: ");
                        string nombreDoctor = Console.ReadLine();
                        Console.Write("Ingrese DNI: ");
                        string dniDoctor = Console.ReadLine();
                        Console.Write("Ingrese especialidad: ");
                        string especialidad = Console.ReadLine();
                        Console.Write("Ingrese el telefono: ");
                        int telD = int.Parse(Console.ReadLine());
                        Console.Write("Ingrese email: ");
                        string emailD = Console.ReadLine();
                        Console.Write("Ingrese direccion: ");
                        string directionD = Console.ReadLine();


                        Doctor nuevoDoctor = new Doctor(nombreDoctor, dniDoctor, especialidad, telD, emailD, directionD);
                        doctores.Add(nuevoDoctor);
                        Console.WriteLine($"¡Doctor {nombreDoctor} creado exitosamente!");
                        break;

                    case "3":
                        Console.WriteLine("\n=== LISTA DE PACIENTES ===");
                        if (pacientes.Count == 0)
                        {
                            Console.WriteLine("No hay pacientes registrados.");
                        }
                        else
                        {
                            for (int i = 0; i < pacientes.Count; i++)
                            {
                                Console.WriteLine($"\n--- Paciente #{i + 1} ---");
                                pacientes[i].print();
                            }
                        }
                        break;

                    case "4":
                        Console.WriteLine("\n=== LISTA DE DOCTORES ===");
                        if (doctores.Count == 0)
                        {
                            Console.WriteLine("No hay doctores registrados.");
                        }
                        else
                        {
                            for (int i = 0; i < doctores.Count; i++)
                            {
                                Console.WriteLine($"\n--- Doctor #{i + 1} ---");
                                doctores[i].print();
                            }
                        }
                        break;

                    case "5":
                        Console.WriteLine("\nPor favor coloque el dni para ver su notificacion");
                        string dniP = Console.ReadLine();
                        Paciente paciente = pacientes.Find(item => item.getDni() == dniP);
                        if(paciente != null)
                        {
                            Console.WriteLine($"Su notificacion es: ");
                            paciente.notify();
                        }
                        else
                        {
                            Console.WriteLine("Paciente no encontrada");

                        }

                        //Console.WriteLine("\n=== Notificacion Pacientes ===");

                        break;

                    case "6":
                        Console.WriteLine("\nPor favor coloque el dni para ver su notificacion");
                        string dniD = Console.ReadLine();
                        Doctor doctor = doctores.Find(item => item.getDni() == dniD);
                        if (doctor != null)
                        {
                            Console.WriteLine($"Su notificacion es: ");
                            doctor.notify();
                        }
                        else
                        {
                            Console.WriteLine("doctor no encontrado(a)");

                        }
                        break;
                    case "7":
                        Console.WriteLine("¡Gracias!");
                        return;

                    default:
                        Console.WriteLine("Opción inválida. Intente nuevamente.");
                        break;
                }
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }
    }
}
