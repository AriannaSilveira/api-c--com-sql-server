--Para gerar as tabelas que precisamos:

CREATE TABLE Addresses (
  id INT PRIMARY KEY IDENTITY(1,1),
  street VARCHAR(255) NOT NULL,
  district VARCHAR(255) NOT NULL,
  city VARCHAR(255) NOT NULL,
  state VARCHAR(2) NOT NULL,
);


CREATE TABLE Clients (
  id INT PRIMARY KEY IDENTITY(1,1),
  name VARCHAR(255) NOT NULL,
  email VARCHAR(255) UNIQUE,
  phone VARCHAR(20),
  address_id INT,
  FOREIGN KEY (address_id) REFERENCES Addresses(id)
);

CREATE TABLE Pets(
  id INT PRIMARY KEY IDENTITY(1,1),
  name VARCHAR(255) NOT NULL,
  age INT,
  type VARCHAR(100),
  breed VARCHAR(100),
  client_id INT,
  FOREIGN KEY (client_id) REFERENCES Clients(id)
);
