using TestClean.Application.TodoLists.Queries.ExportTodos;

namespace TestClean.Application.Common.Interfaces;
public interface ICsvFileBuilder
{
    byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records);
}
