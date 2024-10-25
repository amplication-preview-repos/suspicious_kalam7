using CompanionService.APIs.Common;
using CompanionService.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;

namespace CompanionService.APIs.Dtos;

[BindProperties(SupportsGet = true)]
public class SessionFindManyArgs : FindManyInput<Session, SessionWhereInput> { }
