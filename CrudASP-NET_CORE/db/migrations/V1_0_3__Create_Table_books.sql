CREATE TABLE IF NOT EXISTS books(
		id VARCHAR(127) NOT NULL,
        autor LONGTEXT,
        launchDate DATETIME(6) NOT NULL,
        price DECIMAL(65,2) NOT NULL,
        title LONGTEXT,
        PRIMARY KEY (id)
)ENGINE=InnoDB DEFAULT CHARSET=latin1;