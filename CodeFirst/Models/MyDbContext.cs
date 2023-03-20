using Microsoft.EntityFrameworkCore;

namespace CodeFirst.Models
{
    public class MyDbContext : DbContext
    {

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Agenda>().HasKey(a => new {a.IDPaciente,a.IDOdontologo});
           
            modelBuilder.Entity<Agenda>().Property(a => a.Motivo).HasMaxLength(50);
            modelBuilder.Entity<Agenda>().Property(a => a.Fecha_Hora_Inicio).HasColumnType("date");
            modelBuilder.Entity<Agenda>().Property(a => a.Fecha_Hora_Fin).HasColumnType("date");
            //modelBuilder.Entity<Agenda>().HasOne<Odontologo>(a => a.Odontologo).WithMany(a =>a.Agendas).HasForeignKey(a =>a.IDOdontologo);
            //modelBuilder.Entity<Agenda>().HasOne<Odontologo>(a => a.Odontologo).WithMany(a => a.Agendas).HasForeignKey(a => a.IDOdontologo);
            modelBuilder.Entity<Agenda>().HasOne<Paciente>(a => a.Paciente).WithMany(a => a.Agendas).HasForeignKey(a => a.IDPaciente);
          



            //-------------------------------------------------------------------------------------------------

            modelBuilder.Entity<Paciente>().HasKey(p => p.IDPaciente);
            modelBuilder.Entity<Paciente>().Property(p => p.P_Nombre).HasMaxLength(50);
            modelBuilder.Entity<Paciente>().Property(p => p.P_DNI).HasMaxLength(50);
            modelBuilder.Entity<Paciente>().Property(p => p.P_Domicilio).HasMaxLength(50);
            modelBuilder.Entity<Paciente>().Property(p => p.P_Telefono).HasMaxLength(50); ;
            modelBuilder.Entity<Paciente>().Property(p => p.P_FechaNac).HasColumnType("date");
            modelBuilder.Entity<Paciente>().Property(p => p.P_Ocupacion).HasMaxLength(50);

            //-------------------------------------------------------------------------------------------------

            modelBuilder.Entity<Historial>().HasKey(h => h.IDHistorial);
            modelBuilder.Entity<Historial>().Property(h => h.H_Pregunta).HasMaxLength(50);
            modelBuilder.Entity<Historial>().Property(h => h.H_Categoria).HasMaxLength(50);
            modelBuilder.Entity<Historial>().Property(h => h.H_Respuesta).HasMaxLength(50);
            modelBuilder.Entity<Historial>().Property(h => h.H_Estado).HasMaxLength(50);
            modelBuilder.Entity<Historial>().HasOne<Paciente>(h => h.Paciente).WithMany(h => h.Historials).HasForeignKey(h => h.IDPaciente);


            //-------------------------------------------------------------------------------------------------

            modelBuilder.Entity<Tutor_Padre>().HasKey(t => t.ID_Tutor_Padre);
            modelBuilder.Entity<Tutor_Padre>().Property(t=>t.TP_Nombre).HasMaxLength(50);
            modelBuilder.Entity<Tutor_Padre>().Property(t => t.TP_Telefono).HasMaxLength(50);
            modelBuilder.Entity<Tutor_Padre>().Property(t => t.TP_Ocupacion).HasMaxLength(50);
            modelBuilder.Entity<Tutor_Padre>().HasOne<Paciente>(t => t.Paciente).WithMany(t => t.Tutor_Padres).HasForeignKey(t => t.IDPaciente);




            //-------------------------------------------------------------------------------------------------

            modelBuilder.Entity<Odontologo>().HasKey(od => od.IDOdontologo);
            modelBuilder.Entity<Odontologo>().Property(od => od.OD_Nombre).HasMaxLength(50);
            modelBuilder.Entity<Odontologo>().Property(od => od.OD_Telefono).HasMaxLength(50);
            modelBuilder.Entity<Odontologo>().Property(od => od.OD_Domicilio).HasMaxLength(50);
            modelBuilder.Entity<Odontologo>().Property(od => od.OD_Turno).HasMaxLength(50);
            modelBuilder.Entity<Odontologo>().Property(od=>od.OD_Usuario).HasMaxLength(50);
            modelBuilder.Entity<Odontologo>().Property(od => od.OD_Password).HasMaxLength(50);


            //-------------------------------------------------------------------------------------------------

            modelBuilder.Entity<Realiza>().HasKey(r => new { r.IDPaciente, r.IDTratamiento });
            modelBuilder.Entity<Realiza>().HasOne<Tratamiento>(r => r.Tratamiento).WithMany(r => r.Realizas).HasForeignKey(r => r.IDTratamiento);
            modelBuilder.Entity<Realiza>().HasOne<Paciente>(r => r.Paciente).WithMany(r => r.Realizas).HasForeignKey(r => r.IDPaciente);
            modelBuilder.Entity<Realiza>().Property(r => r.R_Fecha).HasColumnType("date");
            modelBuilder.Entity<Realiza>().Property(r => r.R_Procedimiento).HasMaxLength(50);

            //-------------------------------------------------------------------------------------------------

            modelBuilder.Entity<Pago_Tratamiento>().HasKey(pt => pt.IDPago_Tramiento);
            modelBuilder.Entity<Pago_Tratamiento>().Property(pt=>pt.PT_Fecha).HasColumnType("date");
            modelBuilder.Entity<Pago_Tratamiento>().Property(pt => pt.PT_Monto);
            modelBuilder.Entity<Pago_Tratamiento>().HasOne<Tratamiento>(pt => pt.Tratamiento).WithMany(pt => pt.Pago_Tratamientos).HasForeignKey(pt => pt.IDTratamiento);
            modelBuilder.Entity<Pago_Tratamiento>().HasOne<Paciente>(pt => pt.Paciente).WithMany(pt => pt.Pago_Tratamientos).HasForeignKey(pt => pt.IDPaciente);


            //-------------------------------------------------------------------------------------------------

            modelBuilder.Entity<Odontograma>().HasKey(o => o.IDOdontograma);
            modelBuilder.Entity<Odontograma>().Property(o => o.O_Posicion);
            modelBuilder.Entity<Odontograma>().Property(o => o.O_Nombre).HasMaxLength(50);
            modelBuilder.Entity<Odontograma>().Property(o => o.Categoria).HasMaxLength(50);
            modelBuilder.Entity<Odontograma>().Property(o => o.O_Estado).HasMaxLength(50);
            modelBuilder.Entity<Odontograma>().HasOne<Tratamiento>(o => o.Tratamiento).WithMany(o => o.Odontogramas).HasForeignKey(pt => pt.IDTratamiento);

            //-------------------------------------------------------------------------------------------------

            modelBuilder.Entity<Receta_Medica>().HasKey(rm => rm.IDReceta_Medica);
            modelBuilder.Entity<Receta_Medica>().Property(rm=>rm.Medicamento).HasMaxLength(50);
            modelBuilder.Entity<Receta_Medica>().Property(rm => rm.Dosis).HasMaxLength(50);
            modelBuilder.Entity<Receta_Medica>().Property(rm => rm.Tiempo).HasMaxLength(50);
            modelBuilder.Entity<Receta_Medica>().HasOne<Tratamiento>(o => o.Tratamiento).WithMany(o => o.Receta_Medicas).HasForeignKey(pt => pt.IDTratamiento);

            //-------------------------------------------------------------------------------------------------
            modelBuilder.Entity<Tratamiento>().HasKey(t => t.IDTratamiento);






        }



        public DbSet<Agenda> agendas { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Historial> Historials { get; set; }
        public DbSet<Odontologo> Odontologos { get; set; }
        public DbSet<Realiza> Realizas { get; set; }
        public DbSet<Tutor_Padre> Tutor_Padres { get; set; }
        public DbSet<Tratamiento> Tratamientos { get; set; }
        public DbSet<Receta_Medica> Receta_Medicas { get; set; }
        public DbSet<Pago_Tratamiento> Pago_Tratamientos { get; set; }
        public DbSet<Odontograma> Odontogramas { get; set; }


    }
}
