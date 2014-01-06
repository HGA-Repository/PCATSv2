BEGIN TRANSACTION


	UPDATE DT_ForecastToCompletes set AccountGroup = 20000 where AccountGroup = 20260
	UPDATE DT_ForecastToCompletes set AccountGroup = 18000 where AccountGroup = 18100
	UPDATE DT_ForecastToCompletes set AccountGroup = 11000 where AccountGroup = 18300
	UPDATE DT_ForecastToCompletes set AccountGroup = 21000 where AccountGroup = 21210
	UPDATE DT_ForecastToCompletes set AccountGroup = 22000 where AccountGroup = 22411
	UPDATE DT_ForecastToCompletes set AccountGroup = 19000 where AccountGroup = 19130
	UPDATE DT_ForecastToCompletes set AccountGroup = 0 where AccountGroup = 9037


COMMIT

