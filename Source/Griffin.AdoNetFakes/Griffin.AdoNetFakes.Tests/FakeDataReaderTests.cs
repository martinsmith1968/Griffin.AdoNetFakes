﻿using System;
using System.Data;
using Xunit;

namespace Griffin.AdoNetFakes.Tests
{
    internal class Person
    {
        public int Id { get; set; }
        public string Name { get;set; }
        public DateTime DateOfBirth { get; set; }
    }

    public class FakeDataReaderTests
    {
        [Fact]
        public void Construct_With_Rows_And_Columns_leaves_SchemaType_as_default_RowData()
        {
            var rows = new[]
            {
                new object[] { 1, "Dave", DateTime.UtcNow }
            };

            var table = new FakeTable(rows);

            var sut = new FakeDataReader(table);

            //Assert.Equal(SchemaDataTypeSource.RowData, sut.SchemaDataTypeSource);
        }

        [Fact]
        public void Construct_With_DataTable_leaves_SchemaType_as_default_RowData()
        {
            var table = new DataTable();

            var sut = new FakeDataReader(table);

            //Assert.Equal(SchemaDataTypeSource.DataTable, sut.SchemaDataTypeSource);
        }

        [Fact]
        public void Construct_With_FakeTable_sets_SchemaType_to_DataTable()
        {
            var table = new FakeTable<Person>();
            table.AddRow(new Person { Id = 1, Name = "Bob", DateOfBirth = new DateTime(1980, 06, 15)});

            var sut = new FakeDataReader(table);

            //Assert.Equal(SchemaDataTypeSource.DataTable, sut.SchemaDataTypeSource);
        }
    }
}
