﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ONLINE_POST.Models;

#nullable disable

namespace ONLINE_POST.Migrations
{
    [DbContext(typeof(post_management_systemContext))]
    partial class post_management_systemContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ONLINE_POST.Models.branch", b =>
                {
                    b.Property<int>("b_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("b_id"), 1L, 1);

                    b.Property<string>("b_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("c_id")
                        .HasColumnType("int");

                    b.HasKey("b_id");

                    b.HasIndex("c_id");

                    b.ToTable("branches");
                });

            modelBuilder.Entity("ONLINE_POST.Models.charge", b =>
                {
                    b.Property<int>("c_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("c_id"), 1L, 1);

                    b.Property<int>("c_rate")
                        .HasColumnType("int");

                    b.Property<int>("max_weight")
                        .HasColumnType("int");

                    b.Property<int>("min_weight")
                        .HasColumnType("int");

                    b.HasKey("c_id");

                    b.ToTable("Charges");
                });

            modelBuilder.Entity("ONLINE_POST.Models.City", b =>
                {
                    b.Property<int>("c_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("c_id"), 1L, 1);

                    b.Property<string>("c_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("c_id");

                    b.ToTable("cities");
                });

            modelBuilder.Entity("ONLINE_POST.Models.contact", b =>
                {
                    b.Property<int>("c_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("c_id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("c_id");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("ONLINE_POST.Models.customer_package", b =>
                {
                    b.Property<int>("c_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("c_id"), 1L, 1);

                    b.Property<DateTime>("expired")
                        .HasColumnType("datetime2");

                    b.Property<int>("package_discount")
                        .HasColumnType("int");

                    b.Property<string>("package_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("package_price")
                        .HasColumnType("int");

                    b.Property<int>("user_id")
                        .HasColumnType("int");

                    b.Property<string>("user_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("c_id");

                    b.HasIndex("user_id");

                    b.ToTable("Customer_Packages");
                });

            modelBuilder.Entity("ONLINE_POST.Models.Deliverable", b =>
                {
                    b.Property<int>("DeliverableId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DeliverableId"), 1L, 1);

                    b.Property<string>("Contact_Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateDelivered")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfPosting")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateReceived")
                        .HasColumnType("datetime2");

                    b.Property<string>("DestinationAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SenderAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Total_Price")
                        .HasColumnType("int");

                    b.Property<string>("Tracking_Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TypeOfDelivery")
                        .HasColumnType("int");

                    b.Property<int>("User_id")
                        .HasColumnType("int");

                    b.Property<decimal>("Weight")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("branch_id")
                        .HasColumnType("int");

                    b.Property<int>("c_id")
                        .HasColumnType("int");

                    b.Property<string>("package_type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("pay_id")
                        .HasColumnType("int");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DeliverableId");

                    b.HasIndex("TypeOfDelivery");

                    b.HasIndex("User_id");

                    b.HasIndex("branch_id");

                    b.HasIndex("c_id");

                    b.HasIndex("pay_id");

                    b.ToTable("Deliverables");
                });

            modelBuilder.Entity("ONLINE_POST.Models.delivery_history", b =>
                {
                    b.Property<int>("DeliverableId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DeliverableId"), 1L, 1);

                    b.Property<string>("Contact_Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateDelivered")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfPosting")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateReceived")
                        .HasColumnType("datetime2");

                    b.Property<string>("DestinationAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SenderAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Total_Price")
                        .HasColumnType("int");

                    b.Property<string>("Tracking_Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Weight")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("branch_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("normal_charges")
                        .HasColumnType("int");

                    b.Property<string>("package_type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("service_charges")
                        .HasColumnType("int");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DeliverableId");

                    b.ToTable("Delivery_Histories");
                });

            modelBuilder.Entity("ONLINE_POST.Models.emplog", b =>
                {
                    b.Property<int>("EId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EId"), 1L, 1);

                    b.Property<int>("Branch")
                        .HasColumnType("int");

                    b.Property<string>("EEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ERoleId")
                        .HasColumnType("int");

                    b.Property<string>("EUserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EId");

                    b.HasIndex("Branch");

                    b.HasIndex("ERoleId");

                    b.ToTable("emplogs");
                });

            modelBuilder.Entity("ONLINE_POST.Models.EmployeeInformation", b =>
                {
                    b.Property<int>("EId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("e_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EId"), 1L, 1);

                    b.Property<int>("Branch")
                        .HasColumnType("int");

                    b.Property<string>("EEmail")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("e_email");

                    b.Property<string>("EPassword")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("e_password");

                    b.Property<int?>("ERoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("e_role_id")
                        .HasDefaultValueSql("((3))");

                    b.Property<string>("EUserName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("e_user_name");

                    b.HasKey("EId")
                        .HasName("PK__employee__3E2ED64A7C1E550E");

                    b.HasIndex("Branch");

                    b.HasIndex("ERoleId");

                    b.HasIndex(new[] { "EEmail" }, "UQ__employee__12E5DDF5AACC7E40")
                        .IsUnique();

                    b.HasIndex(new[] { "EUserName" }, "UQ__employee__EA4040794CADA275")
                        .IsUnique();

                    b.ToTable("employee_informations", (string)null);
                });

            modelBuilder.Entity("ONLINE_POST.Models.extras.form", b =>
                {
                    b.Property<int>("f_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("f_id"), 1L, 1);

                    b.Property<string>("f_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("f_id");

                    b.ToTable("Forms");
                });

            modelBuilder.Entity("ONLINE_POST.Models.package", b =>
                {
                    b.Property<int>("p_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("p_id"), 1L, 1);

                    b.Property<int>("p_dis")
                        .HasColumnType("int");

                    b.Property<string>("p_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("p_price")
                        .HasColumnType("int");

                    b.HasKey("p_id");

                    b.ToTable("Packages");
                });

            modelBuilder.Entity("ONLINE_POST.Models.payment", b =>
                {
                    b.Property<int>("p_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("p_id"), 1L, 1);

                    b.Property<string>("p_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("p_id");

                    b.ToTable("payments");
                });

            modelBuilder.Entity("ONLINE_POST.Models.PersonalInformation", b =>
                {
                    b.Property<int>("PId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("p_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PId"), 1L, 1);

                    b.Property<string>("PEmail")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("p_email");

                    b.Property<string>("PPassword")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("p_password");

                    b.Property<int?>("PRoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("p_role_id")
                        .HasDefaultValueSql("((2))");

                    b.Property<string>("PUserName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("p_user_name");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PId")
                        .HasName("PK__personal__82E06B91B4ACF851");

                    b.HasIndex("PRoleId");

                    b.HasIndex(new[] { "PUserName" }, "UQ__personal__05B441C35D5C8B1F")
                        .IsUnique();

                    b.HasIndex(new[] { "PEmail" }, "UQ__personal__37393E4664DDC0F2")
                        .IsUnique();

                    b.ToTable("personal_informations", (string)null);
                });

            modelBuilder.Entity("ONLINE_POST.Models.Role", b =>
                {
                    b.Property<int>("RId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("r_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RId"), 1L, 1);

                    b.Property<string>("RName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("r_name");

                    b.HasKey("RId")
                        .HasName("PK__roles__C476232731402581");

                    b.ToTable("roles", (string)null);
                });

            modelBuilder.Entity("ONLINE_POST.Models.servicetype", b =>
                {
                    b.Property<int>("s_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("s_id"), 1L, 1);

                    b.Property<int>("service_charges")
                        .HasColumnType("int");

                    b.Property<string>("service_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("s_id");

                    b.ToTable("servicetypes");
                });

            modelBuilder.Entity("ONLINE_POST.Models.status", b =>
                {
                    b.Property<int>("s_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("s_id"), 1L, 1);

                    b.Property<string>("s_type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("s_id");

                    b.ToTable("Statuses");
                });

            modelBuilder.Entity("ONLINE_POST.Models.branch", b =>
                {
                    b.HasOne("ONLINE_POST.Models.City", "city")
                        .WithMany("branches")
                        .HasForeignKey("c_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("city");
                });

            modelBuilder.Entity("ONLINE_POST.Models.customer_package", b =>
                {
                    b.HasOne("ONLINE_POST.Models.PersonalInformation", "PersonalInformation")
                        .WithMany("customer_Packages")
                        .HasForeignKey("user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PersonalInformation");
                });

            modelBuilder.Entity("ONLINE_POST.Models.Deliverable", b =>
                {
                    b.HasOne("ONLINE_POST.Models.servicetype", "service")
                        .WithMany("deliverables")
                        .HasForeignKey("TypeOfDelivery")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ONLINE_POST.Models.PersonalInformation", "PersonalInformation")
                        .WithMany("delivery")
                        .HasForeignKey("User_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ONLINE_POST.Models.branch", "Branch")
                        .WithMany("deliverables")
                        .HasForeignKey("branch_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ONLINE_POST.Models.charge", "charges")
                        .WithMany("deliverables")
                        .HasForeignKey("c_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ONLINE_POST.Models.payment", "payments")
                        .WithMany("deliverables")
                        .HasForeignKey("pay_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Branch");

                    b.Navigation("PersonalInformation");

                    b.Navigation("charges");

                    b.Navigation("payments");

                    b.Navigation("service");
                });

            modelBuilder.Entity("ONLINE_POST.Models.emplog", b =>
                {
                    b.HasOne("ONLINE_POST.Models.branch", "branch")
                        .WithMany()
                        .HasForeignKey("Branch")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ONLINE_POST.Models.Role", "ERole")
                        .WithMany()
                        .HasForeignKey("ERoleId");

                    b.Navigation("ERole");

                    b.Navigation("branch");
                });

            modelBuilder.Entity("ONLINE_POST.Models.EmployeeInformation", b =>
                {
                    b.HasOne("ONLINE_POST.Models.branch", "branch")
                        .WithMany("employees")
                        .HasForeignKey("Branch")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ONLINE_POST.Models.Role", "ERole")
                        .WithMany("EmployeeInformations")
                        .HasForeignKey("ERoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK__employee___e_rol__3B75D760");

                    b.Navigation("ERole");

                    b.Navigation("branch");
                });

            modelBuilder.Entity("ONLINE_POST.Models.PersonalInformation", b =>
                {
                    b.HasOne("ONLINE_POST.Models.Role", "PRole")
                        .WithMany("PersonalInformations")
                        .HasForeignKey("PRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK__personal___p_rol__412EB0B6");

                    b.Navigation("PRole");
                });

            modelBuilder.Entity("ONLINE_POST.Models.branch", b =>
                {
                    b.Navigation("deliverables");

                    b.Navigation("employees");
                });

            modelBuilder.Entity("ONLINE_POST.Models.charge", b =>
                {
                    b.Navigation("deliverables");
                });

            modelBuilder.Entity("ONLINE_POST.Models.City", b =>
                {
                    b.Navigation("branches");
                });

            modelBuilder.Entity("ONLINE_POST.Models.payment", b =>
                {
                    b.Navigation("deliverables");
                });

            modelBuilder.Entity("ONLINE_POST.Models.PersonalInformation", b =>
                {
                    b.Navigation("customer_Packages");

                    b.Navigation("delivery");
                });

            modelBuilder.Entity("ONLINE_POST.Models.Role", b =>
                {
                    b.Navigation("EmployeeInformations");

                    b.Navigation("PersonalInformations");
                });

            modelBuilder.Entity("ONLINE_POST.Models.servicetype", b =>
                {
                    b.Navigation("deliverables");
                });
#pragma warning restore 612, 618
        }
    }
}
