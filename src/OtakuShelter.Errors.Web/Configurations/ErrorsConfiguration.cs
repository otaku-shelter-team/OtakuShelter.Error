namespace OtakuShelter.Errors
{
	public class ErrorsConfiguration
	{
		public string Name { get; set; }
		
		public ErrorsDatabaseConfiguration Database { get; set; }
		public ErrorsJwtConfiguration Jwt { get; set; }
		public ErrorsRabbitMqConfiguration RabbitMq { get; set; }
		public ErrorsRoleConfiguration Roles { get; set; }
	}
}