﻿using System.Text.Json.Serialization;

namespace pdbme.pdbInfrastructure.NzbIndexer.Newznab2;

public class IndexerResultNewznab2
{
    [JsonPropertyName("channel")]
    public IndexerResultNewznab2? Channel { get; set; }
}
