using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Back_EndAPI.Models;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<AccountOwner> AccountOwners { get; set; }

    public virtual DbSet<AccountTxn> AccountTxns { get; set; }

    public virtual DbSet<Appointment> Appointments { get; set; }

    public virtual DbSet<AppointmentDiagnosis> AppointmentDiagnoses { get; set; }

    public virtual DbSet<AppointmentTreatment> AppointmentTreatments { get; set; }

    public virtual DbSet<Bill> Bills { get; set; }

    public virtual DbSet<ChanceCard> ChanceCards { get; set; }

    public virtual DbSet<Character> Characters { get; set; }

    public virtual DbSet<CommunityChestCard> CommunityChestCards { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Customer1> Customers1 { get; set; }

    public virtual DbSet<Date> Dates { get; set; }

    public virtual DbSet<Date1> Dates1 { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<DepositAccount> DepositAccounts { get; set; }

    public virtual DbSet<DepositType> DepositTypes { get; set; }

    public virtual DbSet<Diagnosis> Diagnoses { get; set; }

    public virtual DbSet<Doctor> Doctors { get; set; }

    public virtual DbSet<Driver> Drivers { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Employee1> Employees1 { get; set; }

    public virtual DbSet<Game> Games { get; set; }

    public virtual DbSet<JailStatus> JailStatuses { get; set; }

    public virtual DbSet<LoanAccount> LoanAccounts { get; set; }

    public virtual DbSet<LoanType> LoanTypes { get; set; }

    public virtual DbSet<Neighborhood> Neighborhoods { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Payment1> Payments1 { get; set; }

    public virtual DbSet<Player> Players { get; set; }

    public virtual DbSet<Player1> Players1 { get; set; }

    public virtual DbSet<ProcLog> ProcLogs { get; set; }

    public virtual DbSet<Property> Properties { get; set; }

    public virtual DbSet<PropertyOwnership> PropertyOwnerships { get; set; }

    public virtual DbSet<Race> Races { get; set; }

    public virtual DbSet<RaceResult> RaceResults { get; set; }

    public virtual DbSet<Reservation> Reservations { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<Roomtype> Roomtypes { get; set; }

    public virtual DbSet<Roster> Rosters { get; set; }

    public virtual DbSet<Season> Seasons { get; set; }

    public virtual DbSet<Team> Teams { get; set; }

    public virtual DbSet<Tenancy> Tenancies { get; set; }

    public virtual DbSet<Track> Tracks { get; set; }

    public virtual DbSet<Treatment> Treatments { get; set; }

    public virtual DbSet<Vendor> Vendors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=database-1.cisqkskacvfb.us-west-2.rds.amazonaws.com;Port=5432;Database=db26_riley_rust;Username=riley_rust;Password=65235802z303383246;SSL Mode=Require;Trust Server Certificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("account_pkey");

            entity.ToTable("account", "bank");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.OpenedOn).HasColumnName("opened_on");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasColumnName("status");
        });

        modelBuilder.Entity<AccountOwner>(entity =>
        {
            entity.HasKey(e => new { e.AccountId, e.CustomerId }).HasName("account_owner_pkey");

            entity.ToTable("account_owner", "bank");

            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.AddedOn).HasColumnName("added_on");
            entity.Property(e => e.IsPrimary).HasColumnName("is_primary");

            entity.HasOne(d => d.Account).WithMany(p => p.AccountOwners)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("account_owner_account_id_fkey");

            entity.HasOne(d => d.Customer).WithMany(p => p.AccountOwners)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("account_owner_customer_id_fkey");
        });

        modelBuilder.Entity<AccountTxn>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("account_txn_pkey");

            entity.ToTable("account_txn", "bank");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.Amount)
                .HasPrecision(12, 2)
                .HasColumnName("amount");
            entity.Property(e => e.AtmTxnId)
                .HasMaxLength(80)
                .HasColumnName("atm_txn_id");
            entity.Property(e => e.Channel)
                .HasMaxLength(10)
                .HasColumnName("channel");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.Memo)
                .HasMaxLength(200)
                .HasColumnName("memo");
            entity.Property(e => e.TxnDate).HasColumnName("txn_date");
            entity.Property(e => e.TxnType)
                .HasMaxLength(12)
                .HasColumnName("txn_type");

            entity.HasOne(d => d.Account).WithMany(p => p.AccountTxns)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("account_txn_account_id_fkey");

            entity.HasOne(d => d.Employee).WithMany(p => p.AccountTxns)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("account_txn_employee_id_fkey");
        });

        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.HasKey(e => e.AppointmentId).HasName("appointments_pkey");

            entity.ToTable("appointments", "Healthcare");

            entity.Property(e => e.AppointmentId)
                .ValueGeneratedNever()
                .HasColumnName("appointment_id");
            entity.Property(e => e.AppointmentDatetime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("appointment_datetime");
            entity.Property(e => e.DoctorId).HasColumnName("doctor_id");
            entity.Property(e => e.PatientId).HasColumnName("patient_id");
            entity.Property(e => e.ReasonForVisit)
                .HasMaxLength(250)
                .HasColumnName("reason_for_visit");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasColumnName("status");

            entity.HasOne(d => d.Doctor).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.DoctorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("appointments_doctor_id_fkey");

            entity.HasOne(d => d.Patient).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("appointments_patient_id_fkey");
        });

        modelBuilder.Entity<AppointmentDiagnosis>(entity =>
        {
            entity.HasKey(e => new { e.AppointmentId, e.DiagnosisId }).HasName("appointment_diagnoses_pkey");

            entity.ToTable("appointment_diagnoses", "Healthcare");

            entity.Property(e => e.AppointmentId).HasColumnName("appointment_id");
            entity.Property(e => e.DiagnosisId).HasColumnName("diagnosis_id");
            entity.Property(e => e.Notes)
                .HasMaxLength(250)
                .HasColumnName("notes");

            entity.HasOne(d => d.Appointment).WithMany(p => p.AppointmentDiagnoses)
                .HasForeignKey(d => d.AppointmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("appointment_diagnoses_appointment_id_fkey");

            entity.HasOne(d => d.Diagnosis).WithMany(p => p.AppointmentDiagnoses)
                .HasForeignKey(d => d.DiagnosisId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("appointment_diagnoses_diagnosis_id_fkey");
        });

        modelBuilder.Entity<AppointmentTreatment>(entity =>
        {
            entity.HasKey(e => new { e.AppointmentId, e.TreatmentId }).HasName("appointment_treatments_pkey");

            entity.ToTable("appointment_treatments", "Healthcare");

            entity.Property(e => e.AppointmentId).HasColumnName("appointment_id");
            entity.Property(e => e.TreatmentId).HasColumnName("treatment_id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.UnitCostAtTime)
                .HasPrecision(10, 2)
                .HasColumnName("unit_cost_at_time");

            entity.HasOne(d => d.Appointment).WithMany(p => p.AppointmentTreatments)
                .HasForeignKey(d => d.AppointmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("appointment_treatments_appointment_id_fkey");

            entity.HasOne(d => d.Treatment).WithMany(p => p.AppointmentTreatments)
                .HasForeignKey(d => d.TreatmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("appointment_treatments_treatment_id_fkey");
        });

        modelBuilder.Entity<Bill>(entity =>
        {
            entity.HasKey(e => e.BillId).HasName("bills_pkey");

            entity.ToTable("bills", "Healthcare");

            entity.Property(e => e.BillId)
                .ValueGeneratedNever()
                .HasColumnName("bill_id");
            entity.Property(e => e.AppointmentId).HasColumnName("appointment_id");
            entity.Property(e => e.PatientId).HasColumnName("patient_id");
            entity.Property(e => e.PaymentStatus)
                .HasMaxLength(20)
                .HasColumnName("payment_status");
            entity.Property(e => e.TotalAmount)
                .HasPrecision(10, 2)
                .HasColumnName("total_amount");

            entity.HasOne(d => d.Appointment).WithMany(p => p.Bills)
                .HasForeignKey(d => d.AppointmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("bills_appointment_id_fkey");

            entity.HasOne(d => d.Patient).WithMany(p => p.Bills)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("bills_patient_id_fkey");
        });

        modelBuilder.Entity<ChanceCard>(entity =>
        {
            entity.HasKey(e => e.CardId).HasName("chance_card_pkey");

            entity.ToTable("chance_card", "Monopoly");

            entity.Property(e => e.CardId).HasColumnName("card_id");
            entity.Property(e => e.Description).HasColumnName("description");
        });

        modelBuilder.Entity<Character>(entity =>
        {
            entity.HasKey(e => e.CharacterId).HasName("character_pkey");

            entity.ToTable("character");

            entity.Property(e => e.CharacterId).HasColumnName("character_id");
            entity.Property(e => e.Class)
                .HasMaxLength(50)
                .HasColumnName("class");
            entity.Property(e => e.Health).HasColumnName("health");
            entity.Property(e => e.Level).HasColumnName("level");
            entity.Property(e => e.Mana).HasColumnName("mana");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<CommunityChestCard>(entity =>
        {
            entity.HasKey(e => e.CardId).HasName("community_chest_card_pkey");

            entity.ToTable("community_chest_card", "Monopoly");

            entity.Property(e => e.CardId).HasColumnName("card_id");
            entity.Property(e => e.Description).HasColumnName("description");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("customer_pkey");

            entity.ToTable("customer", "bank");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(200)
                .HasColumnName("address");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .HasColumnName("phone");
            entity.Property(e => e.Taxid)
                .HasMaxLength(20)
                .HasColumnName("taxid");
        });

        modelBuilder.Entity<Customer1>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("customer_pkey");

            entity.ToTable("customer", "topic10");

            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("last_name");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");
        });

        modelBuilder.Entity<Date>(entity =>
        {
            entity.HasKey(e => e.DateId).HasName("date_pkey");

            entity.ToTable("date");

            entity.Property(e => e.DateId).HasColumnName("date_id");
            entity.Property(e => e.CalendarDate).HasColumnName("calendar_date");
            entity.Property(e => e.DayOfWeek)
                .HasMaxLength(10)
                .HasColumnName("day_of_week");
        });

        modelBuilder.Entity<Date1>(entity =>
        {
            entity.HasKey(e => e.DateId).HasName("date_pkey");

            entity.ToTable("date", "topic10");

            entity.Property(e => e.DateId).HasColumnName("date_id");
            entity.Property(e => e.CalendarDate).HasColumnName("calendar_date");
            entity.Property(e => e.DayOfWeek)
                .HasMaxLength(10)
                .HasColumnName("day_of_week");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("departments_pkey");

            entity.ToTable("departments", "Healthcare");

            entity.Property(e => e.DepartmentId)
                .ValueGeneratedNever()
                .HasColumnName("department_id");
            entity.Property(e => e.Location)
                .HasMaxLength(150)
                .HasColumnName("location");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<DepositAccount>(entity =>
        {
            entity.HasKey(e => e.AccountId).HasName("deposit_account_pkey");

            entity.ToTable("deposit_account", "bank");

            entity.Property(e => e.AccountId)
                .ValueGeneratedNever()
                .HasColumnName("account_id");
            entity.Property(e => e.DepositTypeId).HasColumnName("deposit_type_id");

            entity.HasOne(d => d.Account).WithOne(p => p.DepositAccount)
                .HasForeignKey<DepositAccount>(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("deposit_account_account_id_fkey");

            entity.HasOne(d => d.DepositType).WithMany(p => p.DepositAccounts)
                .HasForeignKey(d => d.DepositTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("deposit_account_deposit_type_id_fkey");
        });

        modelBuilder.Entity<DepositType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("deposit_type_pkey");

            entity.ToTable("deposit_type", "bank");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Diagnosis>(entity =>
        {
            entity.HasKey(e => e.DiagnosisId).HasName("diagnoses_pkey");

            entity.ToTable("diagnoses", "Healthcare");

            entity.Property(e => e.DiagnosisId)
                .ValueGeneratedNever()
                .HasColumnName("diagnosis_id");
            entity.Property(e => e.Code)
                .HasMaxLength(20)
                .HasColumnName("code");
            entity.Property(e => e.Description)
                .HasMaxLength(250)
                .HasColumnName("description");
        });

        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.HasKey(e => e.DoctorId).HasName("doctors_pkey");

            entity.ToTable("doctors", "Healthcare");

            entity.Property(e => e.DoctorId)
                .ValueGeneratedNever()
                .HasColumnName("doctor_id");
            entity.Property(e => e.DepartmentId).HasColumnName("department_id");
            entity.Property(e => e.Name)
                .HasMaxLength(120)
                .HasColumnName("name");
            entity.Property(e => e.Specialty)
                .HasMaxLength(120)
                .HasColumnName("specialty");

            entity.HasOne(d => d.Department).WithMany(p => p.Doctors)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("doctors_department_id_fkey");
        });

        modelBuilder.Entity<Driver>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("driver_pk");

            entity.ToTable("driver", "topic09");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Birthdate).HasColumnName("birthdate");
            entity.Property(e => e.HeightCm)
                .HasPrecision(10, 2)
                .HasColumnName("height_cm");
            entity.Property(e => e.Name)
                .HasMaxLength(60)
                .HasColumnName("name");
            entity.Property(e => e.WeightKg)
                .HasPrecision(5, 2)
                .HasColumnName("weight_kg");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("employee_pkey");

            entity.ToTable("employee", "bank");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Eeid)
                .HasMaxLength(30)
                .HasColumnName("eeid");
            entity.Property(e => e.HireDate).HasColumnName("hire_date");
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .HasColumnName("phone");
            entity.Property(e => e.Taxid)
                .HasMaxLength(20)
                .HasColumnName("taxid");
        });

        modelBuilder.Entity<Employee1>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("employee_pkey");

            entity.ToTable("employee", "employee");

            entity.HasIndex(e => e.Email, "employee_email_key").IsUnique();

            entity.Property(e => e.EmployeeId)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("employee_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .HasColumnName("first_name");
            entity.Property(e => e.HireDate)
                .HasDefaultValueSql("CURRENT_DATE")
                .HasColumnName("hire_date");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.JobTitle)
                .HasMaxLength(150)
                .HasColumnName("job_title");
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .HasColumnName("last_name");
            entity.Property(e => e.Phone)
                .HasMaxLength(25)
                .HasColumnName("phone");
            entity.Property(e => e.Salary)
                .HasPrecision(12, 2)
                .HasColumnName("salary");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Game>(entity =>
        {
            entity.HasKey(e => e.GameId).HasName("game_pkey");

            entity.ToTable("game", "Monopoly");

            entity.Property(e => e.GameId).HasColumnName("game_id");
            entity.Property(e => e.CurrentPlayerId).HasColumnName("current_player_id");
            entity.Property(e => e.TurnNumber)
                .HasDefaultValue(1)
                .HasColumnName("turn_number");
        });

        modelBuilder.Entity<JailStatus>(entity =>
        {
            entity.HasKey(e => e.PlayerId).HasName("jail_status_pkey");

            entity.ToTable("jail_status", "Monopoly");

            entity.Property(e => e.PlayerId)
                .ValueGeneratedNever()
                .HasColumnName("player_id");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasColumnName("status");
            entity.Property(e => e.TurnsAttempted)
                .HasDefaultValue(0)
                .HasColumnName("turns_attempted");

            entity.HasOne(d => d.Player).WithOne(p => p.JailStatus)
                .HasForeignKey<JailStatus>(d => d.PlayerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_jail_player");
        });

        modelBuilder.Entity<LoanAccount>(entity =>
        {
            entity.HasKey(e => e.AccountId).HasName("loan_account_pkey");

            entity.ToTable("loan_account", "bank");

            entity.Property(e => e.AccountId)
                .ValueGeneratedNever()
                .HasColumnName("account_id");
            entity.Property(e => e.InterestRate)
                .HasPrecision(7, 4)
                .HasColumnName("interest_rate");
            entity.Property(e => e.LoanTypeId).HasColumnName("loan_type_id");

            entity.HasOne(d => d.Account).WithOne(p => p.LoanAccount)
                .HasForeignKey<LoanAccount>(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("loan_account_account_id_fkey");

            entity.HasOne(d => d.LoanType).WithMany(p => p.LoanAccounts)
                .HasForeignKey(d => d.LoanTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("loan_account_loan_type_id_fkey");
        });

        modelBuilder.Entity<LoanType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("loan_type_pkey");

            entity.ToTable("loan_type", "bank");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(40)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Neighborhood>(entity =>
        {
            entity.HasKey(e => e.NeighborhoodId).HasName("neighborhood_pkey");

            entity.ToTable("neighborhood", "Monopoly");

            entity.HasIndex(e => e.Name, "neighborhood_name_key").IsUnique();

            entity.Property(e => e.NeighborhoodId).HasColumnName("neighborhood_id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(e => e.PatientId).HasName("patients_pkey");

            entity.ToTable("patients", "Healthcare");

            entity.Property(e => e.PatientId)
                .ValueGeneratedNever()
                .HasColumnName("patient_id");
            entity.Property(e => e.DateOfBirth).HasColumnName("date_of_birth");
            entity.Property(e => e.InsuranceProvider)
                .HasMaxLength(120)
                .HasColumnName("insurance_provider");
            entity.Property(e => e.Name)
                .HasMaxLength(120)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("payment_pkey");

            entity.ToTable("payment", "topic10");

            entity.Property(e => e.PaymentId).HasColumnName("payment_id");
            entity.Property(e => e.Amount)
                .HasPrecision(8, 2)
                .HasColumnName("amount");
            entity.Property(e => e.PaymentDate).HasColumnName("payment_date");
            entity.Property(e => e.TenancyId).HasColumnName("tenancy_id");

            entity.HasOne(d => d.Tenancy).WithMany(p => p.Payments)
                .HasForeignKey(d => d.TenancyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("payment_tenancy_id_fkey");
        });

        modelBuilder.Entity<Payment1>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("payments_pkey");

            entity.ToTable("payments", "Healthcare");

            entity.Property(e => e.PaymentId)
                .ValueGeneratedNever()
                .HasColumnName("payment_id");
            entity.Property(e => e.Amount)
                .HasPrecision(10, 2)
                .HasColumnName("amount");
            entity.Property(e => e.BillId).HasColumnName("bill_id");
            entity.Property(e => e.PaymentDate).HasColumnName("payment_date");
            entity.Property(e => e.PaymentMethod)
                .HasMaxLength(30)
                .HasColumnName("payment_method");

            entity.HasOne(d => d.Bill).WithMany(p => p.Payment1s)
                .HasForeignKey(d => d.BillId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("payments_bill_id_fkey");
        });

        modelBuilder.Entity<Player>(entity =>
        {
            entity.HasKey(e => e.PlayerId).HasName("player_pkey");

            entity.ToTable("player", "Monopoly");

            entity.Property(e => e.PlayerId).HasColumnName("player_id");
            entity.Property(e => e.BoardPosition).HasColumnName("board_position");
            entity.Property(e => e.Cash)
                .HasDefaultValue(1500)
                .HasColumnName("cash");
            entity.Property(e => e.GameId).HasColumnName("game_id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");

            entity.HasOne(d => d.Game).WithMany(p => p.Players)
                .HasForeignKey(d => d.GameId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_player_game");
        });

        modelBuilder.Entity<Player1>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("player_pkey");

            entity.ToTable("player");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .HasColumnName("phone_number");
            entity.Property(e => e.PlayerName)
                .HasMaxLength(90)
                .HasColumnName("player_name");
        });

        modelBuilder.Entity<ProcLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("proc_log_pkey");

            entity.ToTable("proc_log");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Comment)
                .HasMaxLength(30)
                .HasColumnName("comment");
            entity.Property(e => e.Tstamp)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("tstamp");
        });

        modelBuilder.Entity<Property>(entity =>
        {
            entity.HasKey(e => e.PropertyId).HasName("property_pkey");

            entity.ToTable("property", "Monopoly");

            entity.HasIndex(e => e.Name, "property_name_key").IsUnique();

            entity.Property(e => e.PropertyId).HasColumnName("property_id");
            entity.Property(e => e.BaseRent).HasColumnName("base_rent");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.NeighborhoodId).HasColumnName("neighborhood_id");

            entity.HasOne(d => d.Neighborhood).WithMany(p => p.Properties)
                .HasForeignKey(d => d.NeighborhoodId)
                .HasConstraintName("fk_property_neighborhood");
        });

        modelBuilder.Entity<PropertyOwnership>(entity =>
        {
            entity.HasKey(e => e.PropertyId).HasName("property_ownership_pkey");

            entity.ToTable("property_ownership", "Monopoly");

            entity.Property(e => e.PropertyId)
                .ValueGeneratedNever()
                .HasColumnName("property_id");
            entity.Property(e => e.BuildingCount).HasColumnName("building_count");
            entity.Property(e => e.PlayerId).HasColumnName("player_id");

            entity.HasOne(d => d.Player).WithMany(p => p.PropertyOwnerships)
                .HasForeignKey(d => d.PlayerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_po_player");

            entity.HasOne(d => d.Property).WithOne(p => p.PropertyOwnership)
                .HasForeignKey<PropertyOwnership>(d => d.PropertyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_po_property");
        });

        modelBuilder.Entity<Race>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("race_pk");

            entity.ToTable("race", "topic09");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.StartTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("start_time");
            entity.Property(e => e.TrackId).HasColumnName("track_id");

            entity.HasOne(d => d.Track).WithMany(p => p.Races)
                .HasForeignKey(d => d.TrackId)
                .HasConstraintName("race_track_fk");
        });

        modelBuilder.Entity<RaceResult>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("race_result_pk");

            entity.ToTable("race_result", "topic09");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DriverId).HasColumnName("driver_id");
            entity.Property(e => e.FinishPosition).HasColumnName("finish_position");
            entity.Property(e => e.NumLapsFinished).HasColumnName("num_laps_finished");
            entity.Property(e => e.RaceId).HasColumnName("race_id");
            entity.Property(e => e.TotalRaceTimeSeconds)
                .HasPrecision(15, 5)
                .HasColumnName("total_race_time_seconds");

            entity.HasOne(d => d.Driver).WithMany(p => p.RaceResults)
                .HasForeignKey(d => d.DriverId)
                .HasConstraintName("race_result_driver_fk");

            entity.HasOne(d => d.Race).WithMany(p => p.RaceResults)
                .HasForeignKey(d => d.RaceId)
                .HasConstraintName("race_result_race_fk");
        });

        modelBuilder.Entity<Reservation>(entity =>
        {
            entity.HasKey(e => e.ReservationId).HasName("reservation_pkey");

            entity.ToTable("reservation", "topic10");

            entity.Property(e => e.ReservationId).HasColumnName("reservation_id");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.EndDateId).HasColumnName("end_date_id");
            entity.Property(e => e.RoomTypeId).HasColumnName("room_type_id");
            entity.Property(e => e.StartDateId).HasColumnName("start_date_id");

            entity.HasOne(d => d.Customer).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("reservation_customer_id_fkey");

            entity.HasOne(d => d.EndDate).WithMany(p => p.ReservationEndDates)
                .HasForeignKey(d => d.EndDateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("reservation_end_date_id_fkey");

            entity.HasOne(d => d.StartDate).WithMany(p => p.ReservationStartDates)
                .HasForeignKey(d => d.StartDateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("reservation_start_date_id_fkey");
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.RoomId).HasName("room_pkey");

            entity.ToTable("room", "topic10");

            entity.Property(e => e.RoomId).HasColumnName("room_id");
            entity.Property(e => e.Floor).HasColumnName("floor");
            entity.Property(e => e.RoomNumber)
                .HasMaxLength(10)
                .HasColumnName("room_number");
            entity.Property(e => e.RoomTypeId).HasColumnName("room_type_id");
        });

        modelBuilder.Entity<Roomtype>(entity =>
        {
            entity.HasKey(e => e.RoomTypeId).HasName("roomtype_pkey");

            entity.ToTable("roomtype", "topic10");

            entity.Property(e => e.RoomTypeId).HasColumnName("room_type_id");
            entity.Property(e => e.MaxOccupancy).HasColumnName("max_occupancy");
            entity.Property(e => e.NightlyRate)
                .HasPrecision(8, 2)
                .HasColumnName("nightly_rate");
            entity.Property(e => e.TypeName)
                .HasMaxLength(50)
                .HasColumnName("type_name");
        });

        modelBuilder.Entity<Roster>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("roster_pkey");

            entity.ToTable("roster");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.PlayerId).HasColumnName("player_id");
            entity.Property(e => e.SalaryAmount)
                .HasPrecision(10, 2)
                .HasColumnName("salary_amount");
            entity.Property(e => e.SeasonId).HasColumnName("season_id");
            entity.Property(e => e.TeamId).HasColumnName("team_id");

            entity.HasOne(d => d.Player).WithMany(p => p.Rosters)
                .HasForeignKey(d => d.PlayerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("roster_player_fkey");

            entity.HasOne(d => d.Season).WithMany(p => p.Rosters)
                .HasForeignKey(d => d.SeasonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("roster_season_fkey");

            entity.HasOne(d => d.Team).WithMany(p => p.Rosters)
                .HasForeignKey(d => d.TeamId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("roster_team_fkey");
        });

        modelBuilder.Entity<Season>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("season_pkey");

            entity.ToTable("season");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.SeasonEndDate).HasColumnName("season_end_date");
            entity.Property(e => e.SeasonName).HasColumnName("season_name");
            entity.Property(e => e.SeasonStartDate).HasColumnName("season_start_date");
        });

        modelBuilder.Entity<Team>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("team_pkey");

            entity.ToTable("team");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.City)
                .HasMaxLength(100)
                .HasColumnName("city");
            entity.Property(e => e.TeamName)
                .HasMaxLength(200)
                .HasColumnName("team_name");
        });

        modelBuilder.Entity<Tenancy>(entity =>
        {
            entity.HasKey(e => e.TenancyId).HasName("tenancy_pkey");

            entity.ToTable("tenancy", "topic10");

            entity.Property(e => e.TenancyId).HasColumnName("tenancy_id");
            entity.Property(e => e.CheckIn).HasColumnName("check_in");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.ReservationId).HasColumnName("reservation_id");
            entity.Property(e => e.RoomId).HasColumnName("room_id");

            entity.HasOne(d => d.Customer).WithMany(p => p.Tenancies)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tenancy_customer_id_fkey");

            entity.HasOne(d => d.Reservation).WithMany(p => p.Tenancies)
                .HasForeignKey(d => d.ReservationId)
                .HasConstraintName("tenancy_reservation_id_fkey");

            entity.HasOne(d => d.Room).WithMany(p => p.Tenancies)
                .HasForeignKey(d => d.RoomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tenancy_room_id_fkey");
        });

        modelBuilder.Entity<Track>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("track_pk");

            entity.ToTable("track", "topic09");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .HasColumnName("city");
            entity.Property(e => e.ElevationKm)
                .HasPrecision(10, 2)
                .HasColumnName("elevation_km");
            entity.Property(e => e.LengthKm)
                .HasPrecision(10, 2)
                .HasColumnName("length_km");
        });

        modelBuilder.Entity<Treatment>(entity =>
        {
            entity.HasKey(e => e.TreatmentId).HasName("treatments_pkey");

            entity.ToTable("treatments", "Healthcare");

            entity.Property(e => e.TreatmentId)
                .ValueGeneratedNever()
                .HasColumnName("treatment_id");
            entity.Property(e => e.Description)
                .HasMaxLength(250)
                .HasColumnName("description");
            entity.Property(e => e.StandardCost)
                .HasPrecision(10, 2)
                .HasColumnName("standard_cost");
        });

        modelBuilder.Entity<Vendor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("vendor_pkey");

            entity.ToTable("vendor");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
