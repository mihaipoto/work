using TestClean.Application.Common.Mappings;
using TestClean.Domain.Entities;

namespace TestClean.Application.TodoLists.Queries.ExportTodos;
public class TodoItemRecord : IMapFrom<TodoItem>
{
    public string? Title { get; set; }

    public bool Done { get; set; }
}
