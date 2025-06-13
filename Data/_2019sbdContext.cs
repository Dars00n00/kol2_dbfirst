using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using kol2.Models;

namespace kol2.Data;

public partial class _2019sbdContext : DbContext
{
    public _2019sbdContext()
    {
    }

    public _2019sbdContext(DbContextOptions<_2019sbdContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cwiczenia12Client> Cwiczenia12Clients { get; set; }

    public virtual DbSet<Cwiczenia12ClientTrip> Cwiczenia12ClientTrips { get; set; }

    public virtual DbSet<Cwiczenia12Country> Cwiczenia12Countries { get; set; }

    public virtual DbSet<Cwiczenia12Trip> Cwiczenia12Trips { get; set; }

    public virtual DbSet<K1prCar> K1prCars { get; set; }

    public virtual DbSet<K1prCarRental> K1prCarRentals { get; set; }

    public virtual DbSet<K1prClient> K1prClients { get; set; }

    public virtual DbSet<K1prColor> K1prColors { get; set; }

    public virtual DbSet<K1prModel> K1prModels { get; set; }

    public virtual DbSet<K1rCustomer> K1rCustomers { get; set; }

    public virtual DbSet<K1rDelivery> K1rDeliveries { get; set; }

    public virtual DbSet<K1rDriver> K1rDrivers { get; set; }

    public virtual DbSet<K1rProduct> K1rProducts { get; set; }

    public virtual DbSet<K1rProductDelivery> K1rProductDeliveries { get; set; }

    public virtual DbSet<K2prEvent> K2prEvents { get; set; }

    public virtual DbSet<K2prTag> K2prTags { get; set; }

    public virtual DbSet<K2prUser> K2prUsers { get; set; }

    public virtual DbSet<Race> Races { get; set; }

    public virtual DbSet<RaceParticipation> RaceParticipations { get; set; }

    public virtual DbSet<Racer> Racers { get; set; }

    public virtual DbSet<TpoDydaktyk> TpoDydaktyks { get; set; }

    public virtual DbSet<TpoDydaktykPrzedmiot> TpoDydaktykPrzedmiots { get; set; }

    public virtual DbSet<TpoForma> TpoFormas { get; set; }

    public virtual DbSet<TpoOcena> TpoOcenas { get; set; }

    public virtual DbSet<TpoOsoba> TpoOsobas { get; set; }

    public virtual DbSet<TpoPrzedmiot> TpoPrzedmiots { get; set; }

    public virtual DbSet<TpoPrzedmiotStudent> TpoPrzedmiotStudents { get; set; }

    public virtual DbSet<TpoSemestr> TpoSemestrs { get; set; }

    public virtual DbSet<TpoStatus> TpoStatuses { get; set; }

    public virtual DbSet<TpoStudent> TpoStudents { get; set; }

    public virtual DbSet<Track> Tracks { get; set; }

    public virtual DbSet<TrackRace> TrackRaces { get; set; }

    public virtual DbSet<ZadaniaPerson> ZadaniaPeople { get; set; }

    public virtual DbSet<ZadaniaStatus> ZadaniaStatuses { get; set; }

    public virtual DbSet<ZadaniaTask> ZadaniaTasks { get; set; }

    public virtual DbSet<ZadaniaUrgency> ZadaniaUrgencies { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:Default");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("s31771");

        modelBuilder.Entity<Cwiczenia12Client>(entity =>
        {
            entity.HasKey(e => e.IdClient).HasName("cwiczenia12_Client_pk");

            entity.ToTable("cwiczenia12_Client");

            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(120);
            entity.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(120);
            entity.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(120);
            entity.Property(e => e.Pesel)
                .IsRequired()
                .HasMaxLength(120);
            entity.Property(e => e.Telephone)
                .IsRequired()
                .HasMaxLength(120);
        });

        modelBuilder.Entity<Cwiczenia12ClientTrip>(entity =>
        {
            entity.HasKey(e => new { e.IdClient, e.IdTrip }).HasName("cwiczenia12_Client_Trip_pk");

            entity.ToTable("cwiczenia12_Client_Trip");

            entity.Property(e => e.PaymentDate).HasColumnType("datetime");
            entity.Property(e => e.RegisteredAt).HasColumnType("datetime");

            entity.HasOne(d => d.IdClientNavigation).WithMany(p => p.Cwiczenia12ClientTrips)
                .HasForeignKey(d => d.IdClient)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("cwiczenia12_Client_Trip_Client");

            entity.HasOne(d => d.IdTripNavigation).WithMany(p => p.Cwiczenia12ClientTrips)
                .HasForeignKey(d => d.IdTrip)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("cwiczenia12_Client_Trip_Trip");
        });

        modelBuilder.Entity<Cwiczenia12Country>(entity =>
        {
            entity.HasKey(e => e.IdCountry).HasName("cwiczenia12_Country_pk");

            entity.ToTable("cwiczenia12_Country");

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(120);

            entity.HasMany(d => d.IdTrips).WithMany(p => p.IdCountries)
                .UsingEntity<Dictionary<string, object>>(
                    "Cwiczenia12CountryTrip",
                    r => r.HasOne<Cwiczenia12Trip>().WithMany()
                        .HasForeignKey("IdTrip")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("cwiczenia12_Country_Trip_Trip"),
                    l => l.HasOne<Cwiczenia12Country>().WithMany()
                        .HasForeignKey("IdCountry")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("cwiczenia12_Country_Trip_Country"),
                    j =>
                    {
                        j.HasKey("IdCountry", "IdTrip").HasName("cwiczenia12_Country_Trip_pk");
                        j.ToTable("cwiczenia12_Country_Trip");
                    });
        });

        modelBuilder.Entity<Cwiczenia12Trip>(entity =>
        {
            entity.HasKey(e => e.IdTrip).HasName("cwiczenia12_Trip_pk");

            entity.ToTable("cwiczenia12_Trip");

            entity.Property(e => e.DateFrom).HasColumnType("datetime");
            entity.Property(e => e.DateTo).HasColumnType("datetime");
            entity.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(220);
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(120);
        });

        modelBuilder.Entity<K1prCar>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("cars_pk");

            entity.ToTable("k1pr_cars");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ColorId).HasColumnName("ColorID");
            entity.Property(e => e.ModelId).HasColumnName("ModelID");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.Vin)
                .IsRequired()
                .HasMaxLength(17)
                .HasColumnName("VIN");

            entity.HasOne(d => d.Color).WithMany(p => p.K1prCars)
                .HasForeignKey(d => d.ColorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("cars_colors");

            entity.HasOne(d => d.Model).WithMany(p => p.K1prCars)
                .HasForeignKey(d => d.ModelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("cars_models");
        });

        modelBuilder.Entity<K1prCarRental>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("car_rentals_pk");

            entity.ToTable("k1pr_car_rentals");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CarId).HasColumnName("CarID");
            entity.Property(e => e.ClientId).HasColumnName("ClientID");
            entity.Property(e => e.DateFrom).HasColumnType("datetime");
            entity.Property(e => e.DateTo).HasColumnType("datetime");

            entity.HasOne(d => d.Car).WithMany(p => p.K1prCarRentals)
                .HasForeignKey(d => d.CarId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("car_rentals_cars");

            entity.HasOne(d => d.Client).WithMany(p => p.K1prCarRentals)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("car_rentals_clients");
        });

        modelBuilder.Entity<K1prClient>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("clients_pk");

            entity.ToTable("k1pr_clients");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Address)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(100);
        });

        modelBuilder.Entity<K1prColor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("colors_pk");

            entity.ToTable("k1pr_colors");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);
        });

        modelBuilder.Entity<K1prModel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("models_pk");

            entity.ToTable("k1pr_models");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);
        });

        modelBuilder.Entity<K1rCustomer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("k1r_Customer_pk");

            entity.ToTable("k1r_Customer");

            entity.Property(e => e.CustomerId)
                .ValueGeneratedNever()
                .HasColumnName("customer_id");
            entity.Property(e => e.DateOfBirth)
                .HasColumnType("datetime")
                .HasColumnName("date_of_birth");
            entity.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("last_name");
        });

        modelBuilder.Entity<K1rDelivery>(entity =>
        {
            entity.HasKey(e => e.DeliveryId).HasName("k1r_Delivery_pk");

            entity.ToTable("k1r_Delivery");

            entity.Property(e => e.DeliveryId)
                .ValueGeneratedNever()
                .HasColumnName("delivery_id");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.DriverId).HasColumnName("driver_id");

            entity.HasOne(d => d.Customer).WithMany(p => p.K1rDeliveries)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("k1r_Delivery_Customer");

            entity.HasOne(d => d.Driver).WithMany(p => p.K1rDeliveries)
                .HasForeignKey(d => d.DriverId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("k1r_Delivery_Driver");
        });

        modelBuilder.Entity<K1rDriver>(entity =>
        {
            entity.HasKey(e => e.DriverId).HasName("k1r_Driver_pk");

            entity.ToTable("k1r_Driver");

            entity.Property(e => e.DriverId)
                .ValueGeneratedNever()
                .HasColumnName("driver_id");
            entity.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("last_name");
            entity.Property(e => e.LicenceNumber)
                .IsRequired()
                .HasMaxLength(17)
                .HasColumnName("licence_number");
        });

        modelBuilder.Entity<K1rProduct>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("k1r_Product_pk");

            entity.ToTable("k1r_Product");

            entity.Property(e => e.ProductId)
                .ValueGeneratedNever()
                .HasColumnName("product_id");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");
        });

        modelBuilder.Entity<K1rProductDelivery>(entity =>
        {
            entity.HasKey(e => new { e.ProductId, e.DeliveryId }).HasName("k1r_Product_Delivery_pk");

            entity.ToTable("k1r_Product_Delivery");

            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.DeliveryId).HasColumnName("delivery_id");
            entity.Property(e => e.Amount).HasColumnName("amount");

            entity.HasOne(d => d.Delivery).WithMany(p => p.K1rProductDeliveries)
                .HasForeignKey(d => d.DeliveryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("k1r_Product_Delivery_Delivery");

            entity.HasOne(d => d.Product).WithMany(p => p.K1rProductDeliveries)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("k1r_Product_Delivery_Product");
        });

        modelBuilder.Entity<K2prEvent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("k2pr_Event_pk");

            entity.ToTable("k2pr_Event");

            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(150)
                .IsUnicode(false);

            entity.HasOne(d => d.Organizer).WithMany(p => p.K2prEvents)
                .HasForeignKey(d => d.OrganizerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("k2pr_Event_User");

            entity.HasMany(d => d.Tags).WithMany(p => p.Events)
                .UsingEntity<Dictionary<string, object>>(
                    "K2prEventTag",
                    r => r.HasOne<K2prTag>().WithMany()
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("k2pr_EventTags_Tag"),
                    l => l.HasOne<K2prEvent>().WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("k2pr_EventTags_Event"),
                    j =>
                    {
                        j.HasKey("EventId", "TagId").HasName("k2pr_EventTag_pk");
                        j.ToTable("k2pr_EventTag");
                        j.IndexerProperty<int>("EventId").HasColumnName("Event_Id");
                        j.IndexerProperty<int>("TagId").HasColumnName("Tag_Id");
                    });
        });

        modelBuilder.Entity<K2prTag>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("k2pr_Tag_pk");

            entity.ToTable("k2pr_Tag");

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<K2prUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("k2pr_User_pk");

            entity.ToTable("k2pr_User");

            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Username)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasMany(d => d.Events).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "K2prEventParticipant",
                    r => r.HasOne<K2prEvent>().WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("k2pr_EventParticipant_Event"),
                    l => l.HasOne<K2prUser>().WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("k2pr_EventParticipant_User"),
                    j =>
                    {
                        j.HasKey("UserId", "EventId").HasName("k2pr_EventParticipant_pk");
                        j.ToTable("k2pr_EventParticipant");
                        j.IndexerProperty<int>("UserId").HasColumnName("User_Id");
                        j.IndexerProperty<int>("EventId").HasColumnName("Event_Id");
                    });
        });

        modelBuilder.Entity<Race>(entity =>
        {
            entity.Property(e => e.Location).IsRequired();
            entity.Property(e => e.Name).IsRequired();
        });

        modelBuilder.Entity<RaceParticipation>(entity =>
        {
            entity.HasKey(e => new { e.TrackRaceId, e.RacerId });

            entity.HasIndex(e => e.RacerId, "IX_RaceParticipations_RacerId");

            entity.HasOne(d => d.Racer).WithMany(p => p.RaceParticipations).HasForeignKey(d => d.RacerId);

            entity.HasOne(d => d.TrackRace).WithMany(p => p.RaceParticipations).HasForeignKey(d => d.TrackRaceId);
        });

        modelBuilder.Entity<Racer>(entity =>
        {
            entity.Property(e => e.FirstName).IsRequired();
            entity.Property(e => e.LastName).IsRequired();
        });

        modelBuilder.Entity<TpoDydaktyk>(entity =>
        {
            entity.HasKey(e => e.DydaktykId).HasName("Dydaktyk_pk");

            entity.ToTable("tpo_Dydaktyk");

            entity.Property(e => e.DydaktykId)
                .ValueGeneratedNever()
                .HasColumnName("dydaktyk_id");
            entity.Property(e => e.DataRozpoczecia).HasColumnName("data_rozpoczecia");
            entity.Property(e => e.DataZakonczenia).HasColumnName("data_zakonczenia");
            entity.Property(e => e.Wyplata)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("wyplata");

            entity.HasOne(d => d.Dydaktyk).WithOne(p => p.TpoDydaktyk)
                .HasForeignKey<TpoDydaktyk>(d => d.DydaktykId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Dydaktyk_Osoba");
        });

        modelBuilder.Entity<TpoDydaktykPrzedmiot>(entity =>
        {
            entity.HasKey(e => new { e.PrzedmiotId, e.DydaktykId }).HasName("Dydaktyk_Przedmiot_pk");

            entity.ToTable("tpo_Dydaktyk_Przedmiot");

            entity.Property(e => e.PrzedmiotId).HasColumnName("przedmiot_id");
            entity.Property(e => e.DydaktykId).HasColumnName("dydaktyk_id");
            entity.Property(e => e.SemestrSemestrId).HasColumnName("Semestr_semestr_id");

            entity.HasOne(d => d.Dydaktyk).WithMany(p => p.TpoDydaktykPrzedmiots)
                .HasForeignKey(d => d.DydaktykId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Dydaktyk_Przedmiot_Dydaktyk");

            entity.HasOne(d => d.Przedmiot).WithMany(p => p.TpoDydaktykPrzedmiots)
                .HasForeignKey(d => d.PrzedmiotId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Dydaktyk_Przedmiot_Przedmiot");

            entity.HasOne(d => d.SemestrSemestr).WithMany(p => p.TpoDydaktykPrzedmiots)
                .HasForeignKey(d => d.SemestrSemestrId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Dydaktyk_Przedmiot_Semestr");
        });

        modelBuilder.Entity<TpoForma>(entity =>
        {
            entity.HasKey(e => e.FormaId).HasName("Forma_pk");

            entity.ToTable("tpo_Forma");

            entity.Property(e => e.FormaId)
                .ValueGeneratedNever()
                .HasColumnName("forma_id");
            entity.Property(e => e.Nazwa)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nazwa");
        });

        modelBuilder.Entity<TpoOcena>(entity =>
        {
            entity.HasKey(e => new { e.StudentId, e.PrzedmiotId, e.SemestrId }).HasName("Ocena_pk");

            entity.ToTable("tpo_Ocena");

            entity.Property(e => e.StudentId).HasColumnName("student_id");
            entity.Property(e => e.PrzedmiotId).HasColumnName("przedmiot_id");
            entity.Property(e => e.SemestrId).HasColumnName("semestr_id");
            entity.Property(e => e.DydaktykId).HasColumnName("dydaktyk_id");
            entity.Property(e => e.Ocena)
                .HasColumnType("decimal(2, 1)")
                .HasColumnName("ocena");

            entity.HasOne(d => d.Dydaktyk).WithMany(p => p.TpoOcenas)
                .HasForeignKey(d => d.DydaktykId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Ocena_Dydaktyk");

            entity.HasOne(d => d.Przedmiot).WithMany(p => p.TpoOcenas)
                .HasForeignKey(d => d.PrzedmiotId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Ocena_Przedmiot");

            entity.HasOne(d => d.Semestr).WithMany(p => p.TpoOcenas)
                .HasForeignKey(d => d.SemestrId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Ocena_Semestr");

            entity.HasOne(d => d.Student).WithMany(p => p.TpoOcenas)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Ocena_Student");
        });

        modelBuilder.Entity<TpoOsoba>(entity =>
        {
            entity.HasKey(e => e.OsobaId).HasName("Osoba_pk");

            entity.ToTable("tpo_Osoba");

            entity.Property(e => e.OsobaId)
                .ValueGeneratedNever()
                .HasColumnName("osoba_id");
            entity.Property(e => e.DataUrodzenia).HasColumnName("data_urodzenia");
            entity.Property(e => e.Imie)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("imie");
            entity.Property(e => e.Nazwisko)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nazwisko");
        });

        modelBuilder.Entity<TpoPrzedmiot>(entity =>
        {
            entity.HasKey(e => e.PrzedmiotId).HasName("Przedmiot_pk");

            entity.ToTable("tpo_Przedmiot");

            entity.Property(e => e.PrzedmiotId)
                .ValueGeneratedNever()
                .HasColumnName("przedmiot_id");
            entity.Property(e => e.CzyObowiazkowy)
                .IsRequired()
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("czy_obowiazkowy");
            entity.Property(e => e.FormaId).HasColumnName("forma_id");
            entity.Property(e => e.Nazwa)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nazwa");
            entity.Property(e => e.PunktyEtcs).HasColumnName("punkty_etcs");

            entity.HasOne(d => d.Forma).WithMany(p => p.TpoPrzedmiots)
                .HasForeignKey(d => d.FormaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Przedmiot_Forma");
        });

        modelBuilder.Entity<TpoPrzedmiotStudent>(entity =>
        {
            entity.HasKey(e => new { e.StudentId, e.PrzedmiotId }).HasName("Przedmiot_Student_pk");

            entity.ToTable("tpo_Przedmiot_Student");

            entity.Property(e => e.StudentId).HasColumnName("student_id");
            entity.Property(e => e.PrzedmiotId).HasColumnName("przedmiot_id");
            entity.Property(e => e.SemestrSemestrId).HasColumnName("Semestr_semestr_id");

            entity.HasOne(d => d.Przedmiot).WithMany(p => p.TpoPrzedmiotStudents)
                .HasForeignKey(d => d.PrzedmiotId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Przedmiot_Student_Przedmiot");

            entity.HasOne(d => d.SemestrSemestr).WithMany(p => p.TpoPrzedmiotStudents)
                .HasForeignKey(d => d.SemestrSemestrId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Przedmiot_Student_Semestr");

            entity.HasOne(d => d.Student).WithMany(p => p.TpoPrzedmiotStudents)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Przedmiot_Student_Student");
        });

        modelBuilder.Entity<TpoSemestr>(entity =>
        {
            entity.HasKey(e => e.SemestrId).HasName("Semestr_pk");

            entity.ToTable("tpo_Semestr");

            entity.Property(e => e.SemestrId)
                .ValueGeneratedNever()
                .HasColumnName("semestr_id");
            entity.Property(e => e.NumerSemestru).HasColumnName("numer_semestru");
            entity.Property(e => e.RokAkademicki)
                .IsRequired()
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasColumnName("rok_akademicki");
        });

        modelBuilder.Entity<TpoStatus>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("Status_pk");

            entity.ToTable("tpo_Status");

            entity.Property(e => e.StatusId)
                .ValueGeneratedNever()
                .HasColumnName("status_id");
            entity.Property(e => e.Nazwa)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nazwa");
        });

        modelBuilder.Entity<TpoStudent>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("Student_pk");

            entity.ToTable("tpo_Student");

            entity.Property(e => e.StudentId)
                .ValueGeneratedNever()
                .HasColumnName("student_id");
            entity.Property(e => e.DataRozpoczecia).HasColumnName("data_rozpoczecia");
            entity.Property(e => e.DataZakonczenia).HasColumnName("data_zakonczenia");
            entity.Property(e => e.StatusId).HasColumnName("status_id");

            entity.HasOne(d => d.Status).WithMany(p => p.TpoStudents)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Student_Status");

            entity.HasOne(d => d.Student).WithOne(p => p.TpoStudent)
                .HasForeignKey<TpoStudent>(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Student_Osoba");
        });

        modelBuilder.Entity<Track>(entity =>
        {
            entity.Property(e => e.LengthInKm).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Name).IsRequired();
        });

        modelBuilder.Entity<TrackRace>(entity =>
        {
            entity.HasIndex(e => e.RaceId, "IX_TrackRaces_RaceId");

            entity.HasIndex(e => e.TrackId, "IX_TrackRaces_TrackId");

            entity.HasOne(d => d.Race).WithMany(p => p.TrackRaces).HasForeignKey(d => d.RaceId);

            entity.HasOne(d => d.Track).WithMany(p => p.TrackRaces).HasForeignKey(d => d.TrackId);
        });

        modelBuilder.Entity<ZadaniaPerson>(entity =>
        {
            entity.HasKey(e => e.PersonId).HasName("zadania_Person_pk");

            entity.ToTable("zadania_Person");

            entity.Property(e => e.PersonId)
                .ValueGeneratedNever()
                .HasColumnName("person_id");
            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Fname)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("fname");
            entity.Property(e => e.Lname)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("lname");
        });

        modelBuilder.Entity<ZadaniaStatus>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("zadania_Status_pk");

            entity.ToTable("zadania_Status");

            entity.Property(e => e.StatusId)
                .ValueGeneratedNever()
                .HasColumnName("status_id");
            entity.Property(e => e.Type)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("type");
        });

        modelBuilder.Entity<ZadaniaTask>(entity =>
        {
            entity.HasKey(e => e.TaskId).HasName("zadania_Task_pk");

            entity.ToTable("zadania_Task");

            entity.Property(e => e.TaskId)
                .ValueGeneratedNever()
                .HasColumnName("task_id");
            entity.Property(e => e.DateOfCompletion)
                .HasColumnType("datetime")
                .HasColumnName("date_of_completion");
            entity.Property(e => e.DateOfCreation)
                .HasColumnType("datetime")
                .HasColumnName("date_of_creation");
            entity.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.PersonId).HasColumnName("person_id");
            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.UrgencyId).HasColumnName("urgency_id");

            entity.HasOne(d => d.Person).WithMany(p => p.ZadaniaTasks)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("zadania_Task_Person");

            entity.HasOne(d => d.Status).WithMany(p => p.ZadaniaTasks)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("zadania_Task_Status");

            entity.HasOne(d => d.Urgency).WithMany(p => p.ZadaniaTasks)
                .HasForeignKey(d => d.UrgencyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("zadania_Task_Urgency");
        });

        modelBuilder.Entity<ZadaniaUrgency>(entity =>
        {
            entity.HasKey(e => e.UrgencyId).HasName("zadania_Urgency_pk");

            entity.ToTable("zadania_Urgency");

            entity.Property(e => e.UrgencyId)
                .ValueGeneratedNever()
                .HasColumnName("urgency_id");
            entity.Property(e => e.Type)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("type");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
