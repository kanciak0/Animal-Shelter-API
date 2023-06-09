﻿using Newtonsoft.Json;

namespace Project_API.Entities.AnimalAggregate;

[JsonObject]
public record Animal_ID(Guid Value) : StronglyTypedId<Guid>(Value);