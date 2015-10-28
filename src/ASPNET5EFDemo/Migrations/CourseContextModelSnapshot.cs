using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using ASPNET5EFDemo.Models;
using Microsoft.Data.Entity.SqlServer.Metadata;

namespace ASPNET5EFDemo.Migrations
{
    [DbContext(typeof(CourseContext))]
    partial class CourseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Annotation("ProductVersion", "7.0.0-beta7-15540")
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerIdentityStrategy.IdentityColumn);

            modelBuilder.Entity("ASPNET5EFDemo.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Audience");

                    b.Property<bool>("Customized");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<string>("Prerequisites");

                    b.Key("Id");
                });
        }
    }
}
