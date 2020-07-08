
CREATE TABLE TESTEK2.SEGURO (
	ID VARCHAR2(100) NOT NULL,
	SEGURADOID INTEGER NOT NULL,
	MARCAMODELO VARCHAR2(100) NOT NULL,
	VALORVEICULO DECIMAL NOT NULL,
	VALORSEGURO DECIMAL NOT NULL,
	CONSTRAINT SEGURO_PK PRIMARY KEY (ID)
)
TABLESPACE USERS;

ALTER USER testek2 QUOTA 100M ON USERS;
 


-- Para utilização nos testes unitários

CREATE TABLE TESTEK2TEST.SEGURO (
	ID VARCHAR2(100) NOT NULL,
	SEGURADOID INTEGER NOT NULL,
	MARCAMODELO VARCHAR2(100) NOT NULL,
	VALORVEICULO DECIMAL NOT NULL,
	VALORSEGURO DECIMAL NOT NULL,
	CONSTRAINT SEGURO_PK PRIMARY KEY (ID)
)
TABLESPACE USERS;

ALTER USER testek2test QUOTA 100M ON USERS;


