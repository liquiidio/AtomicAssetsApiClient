﻿using System.Linq;
using AtomicAssetsApiClient.Schemas;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AtomicAssetsApiClient.Test.Schemas
{
    [TestClass]
    public class SchemasApiTest
    {
        [TestMethod]
        public void Schemas()
        {
            AtomicAssetsApiFactory.Version1.SchemasApi.Schemas().GetAwaiter().GetResult().Should().BeOfType<SchemasDto>();
            AtomicAssetsApiFactory.Version1.SchemasApi.Schemas().GetAwaiter().GetResult().Data.Should().BeOfType<SchemasDto.DataDto[]>();
            AtomicAssetsApiFactory.Version1.SchemasApi.Schemas().GetAwaiter().GetResult().Data.Should().HaveCountGreaterThan(1);
            AtomicAssetsApiFactory.Version1.SchemasApi.Schemas(new SchemasUriParameterBuilder().WithLimit(1)).GetAwaiter().GetResult().Data.Should().HaveCount(1);

            AtomicAssetsApiFactory.Version1.SchemasApi.Schemas(new SchemasUriParameterBuilder().WithOrder(SortStrategy.Ascending)).GetAwaiter().GetResult().Should().BeOfType<SchemasDto>();
            AtomicAssetsApiFactory.Version1.SchemasApi.Schemas(new SchemasUriParameterBuilder().WithOrder(SortStrategy.Ascending)).GetAwaiter().GetResult().Data.Should().BeOfType<SchemasDto.DataDto[]>();
        }

        [TestMethod]
        public void Schema()
        {
            var collectionNameToFind = AtomicAssetsApiFactory.Version1.SchemasApi.Schemas().GetAwaiter().GetResult().Data.First().Collection.CollectionName;
            var schemaNameToFind = AtomicAssetsApiFactory.Version1.SchemasApi.Schemas().GetAwaiter().GetResult().Data.First().SchemaName;
            AtomicAssetsApiFactory.Version1.SchemasApi.Schema(collectionNameToFind, schemaNameToFind).GetAwaiter().GetResult().Should().BeOfType<SchemaDto>();
            AtomicAssetsApiFactory.Version1.SchemasApi.Schema(collectionNameToFind, schemaNameToFind).GetAwaiter().GetResult().Data.Should().BeOfType<SchemaDto.DataDto>();
        }

        [TestMethod]
        public void SchemaStats()
        {
            var collectionNameToFind = AtomicAssetsApiFactory.Version1.SchemasApi.Schemas().GetAwaiter().GetResult().Data.First().Collection.CollectionName;
            var schemaNameToFind = AtomicAssetsApiFactory.Version1.SchemasApi.Schemas().GetAwaiter().GetResult().Data.First().SchemaName;
            AtomicAssetsApiFactory.Version1.SchemasApi.SchemaStats(collectionNameToFind, schemaNameToFind).GetAwaiter().GetResult().Should().BeOfType<StatsDto>();
            AtomicAssetsApiFactory.Version1.SchemasApi.SchemaStats(collectionNameToFind, schemaNameToFind).GetAwaiter().GetResult().Data.Should().BeOfType<StatsDto.DataDto>();
        }

        [TestMethod]
        public void SchemaLogs()
        {
            var collectionNameToFind = AtomicAssetsApiFactory.Version1.SchemasApi.Schemas().GetAwaiter().GetResult().Data.First().Collection.CollectionName;
            var schemaNameToFind = AtomicAssetsApiFactory.Version1.SchemasApi.Schemas().GetAwaiter().GetResult().Data.First().SchemaName;
            AtomicAssetsApiFactory.Version1.SchemasApi.SchemaLogs(collectionNameToFind, schemaNameToFind).GetAwaiter().GetResult().Should().BeOfType<LogsDto>();
            AtomicAssetsApiFactory.Version1.SchemasApi.SchemaLogs(collectionNameToFind, schemaNameToFind).GetAwaiter().GetResult().Data.Should().BeOfType<LogsDto.DataDto[]>();
        }
    }
}