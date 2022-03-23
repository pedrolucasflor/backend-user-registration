using backend_user_registration.Data;

builder.Services.AddControllers();
builder.Services.AddDbContext<UserRegistrationContext>(options =>
    options.UseMySql(connectionString, new MySqlServerVersion(new System.Version(8, 0, 22)), mySqlOptions => mySqlOptions.CharSetBehavior(CharSetBehavior.NeverAppend))
);

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
