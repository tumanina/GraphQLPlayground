using GraphQL;
using GraphQL.MicrosoftDI;
using GraphQL.Types;
using GraphQLPlayground.Server;
using GraphQLPlayground.Server.Data;
using GraphQLPlayground.Server.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<OrdersDbContext>(options =>
{
    options.UseSqlServer("Server=.;Initial Catalog=order_db;Persist Security Info=true;Integrated Security=SSPI;Encrypt=false");
});

builder.Services.AddScoped<IOrdersRepository, OrdersRepository>();
builder.Services.AddScoped<ICustomersRepository, CustomersRepository>();
builder.Services.AddScoped<OrdersQuery>();
builder.Services.AddScoped<OrderMutation>();
builder.Services.AddScoped<ISchema, OrdersSchema>(services => new OrdersSchema(new SelfActivatingServiceProvider(services)));
builder.Services.AddGraphQL(options =>
    options.ConfigureExecution((opt, next) =>
    {
        opt.EnableMetrics = true;
        return next(opt);
    })
    .AddSystemTextJson()
    .AddSchema<OrdersSchema>()
);

var app = builder.Build();

app.UseGraphQL();
app.UseGraphQLPlayground();
app.Run();
