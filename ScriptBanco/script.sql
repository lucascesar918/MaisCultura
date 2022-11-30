DROP DATABASE IF EXISTS maiscultura;
CREATE DATABASE maiscultura;
USE maiscultura;

CREATE TABLE sexo(
	sg_sexo VARCHAR(3),
	nm_sexo VARCHAR(45) NOT NULL UNIQUE,

	PRIMARY KEY(sg_sexo)
);

CREATE TABLE tipo_usuario(
	cd_tipo_usuario INT,
	nm_tipo_usuario VARCHAR(45) NOT NULL UNIQUE,

	PRIMARY KEY(cd_tipo_usuario)
);

CREATE TABLE categoria(
	cd_categoria INT,
	nm_categoria VARCHAR(20) NOT NULL UNIQUE,

	PRIMARY KEY(cd_categoria)
);

CREATE TABLE lista_motivo(
	cd_motivo INT,
	nm_motivo VARCHAR(100) NOT NULL UNIQUE,

	PRIMARY KEY(cd_motivo)
);

CREATE TABLE imagem(
	cd_imagem INT,
	nm_imagem TEXT NOT NULL,

	PRIMARY KEY(cd_imagem)
);

CREATE TABLE usuario(
	cd_usuario VARCHAR(20),
	cd_tipo_usuario INT NOT NULL,
	sg_sexo VARCHAR(3),
	nm_usuario VARCHAR(100) NOT NULL,
	nm_email VARCHAR(50) NOT NULL UNIQUE,
	cd_senha VARCHAR(35) NOT NULL,
	nm_documento VARCHAR(15),
	dt_nascimento DATE,

	FOREIGN KEY (sg_sexo)
		REFERENCES sexo(sg_sexo),
	FOREIGN KEY (cd_tipo_usuario)
		REFERENCES tipo_usuario(cd_tipo_usuario),

	PRIMARY KEY (cd_usuario)
);

CREATE TABLE evento(
	cd_evento INT,
	cd_responsavel VARCHAR(20) NOT NULL,
	nm_titulo VARCHAR(140) NOT NULL,
	ds_local TEXT  NOT NULL,
	ds_evento TEXT,

	FOREIGN KEY (cd_responsavel)
		REFERENCES usuario(cd_usuario),

	PRIMARY KEY(cd_evento)
);

CREATE TABLE imagem_evento(
	cd_evento INT,
	cd_imagem INT,

	PRIMARY KEY (cd_evento, cd_imagem),

	FOREIGN KEY (cd_evento)
		REFERENCES evento (cd_evento),

	FOREIGN KEY (cd_imagem)
		REFERENCES imagem (cd_imagem)
);

CREATE TABLE dia_evento(
	cd_evento INT,
	dt_dia DATE,
	hr_inicial TIME NOT NULL,
	hr_final TIME NOT NULL,

	FOREIGN KEY (cd_evento)
		REFERENCES evento(cd_evento),

	PRIMARY KEY (cd_evento, dt_dia)
);

CREATE TABLE avaliacao(
	cd_usuario VARCHAR(20),
	cd_evento INT,
	ds_avaliacao TEXT NOT NULL,
	qt_estrela INT NOT NULL,

	FOREIGN KEY (cd_usuario)
		REFERENCES usuario(cd_usuario),
	FOREIGN KEY (cd_evento)
		REFERENCES evento(cd_evento),

	PRIMARY KEY (cd_usuario, cd_evento)
);

CREATE TABLE interesse(
	cd_evento INT,
	cd_usuario VARCHAR(20),
	
	FOREIGN KEY (cd_evento)
		REFERENCES evento(cd_evento),
	FOREIGN KEY (cd_usuario)
		REFERENCES usuario(cd_usuario),

	PRIMARY KEY (cd_evento, cd_usuario)
);

CREATE TABLE salvar(
	cd_evento INT,
	cd_usuario VARCHAR(20),
	
	FOREIGN KEY (cd_evento)
		REFERENCES evento(cd_evento),
	FOREIGN KEY (cd_usuario)
		REFERENCES usuario(cd_usuario),

	PRIMARY KEY (cd_evento, cd_usuario)
);

CREATE TABLE evento_categoria(
	cd_evento INT,
	cd_categoria INT,

	FOREIGN KEY (cd_categoria)
		REFERENCES categoria(cd_categoria),
	FOREIGN KEY (cd_evento)
		REFERENCES evento(cd_evento),

	PRIMARY KEY (cd_categoria, cd_evento)
);

CREATE TABLE preferencia(
	cd_categoria INT,
	cd_usuario VARCHAR(20),
	
	FOREIGN KEY (cd_categoria)
		REFERENCES categoria(cd_categoria),
	FOREIGN KEY (cd_usuario)
		REFERENCES usuario(cd_usuario),

	PRIMARY KEY (cd_categoria, cd_usuario)
);

CREATE TABLE denuncia(
	cd_denuncia INT, 
	cd_evento INT NOT NULL,
	cd_usuario VARCHAR(20) NOT NULL,
	dt_denuncia DATE NOT NULL,
	hr_denuncia TIME NOT NULL,

	FOREIGN KEY (cd_evento)
		REFERENCES evento(cd_evento),
	FOREIGN KEY (cd_usuario)
		REFERENCES usuario(cd_usuario),
	
	CONSTRAINT PRIMARY KEY (cd_denuncia)
);

CREATE TABLE motivo(
	cd_motivo INT,
	cd_denuncia INT,
	ds_denuncia TEXT,

	FOREIGN KEY (cd_motivo)
		REFERENCES lista_motivo(cd_motivo),
	FOREIGN KEY (cd_denuncia)
		REFERENCES denuncia(cd_denuncia),

	PRIMARY KEY (cd_motivo, cd_denuncia)
);

CREATE TABLE equipe_evento(
	cd_evento INT,
	cd_usuario VARCHAR(20),

	FOREIGN KEY (cd_evento)
		REFERENCES evento(cd_evento),
	FOREIGN KEY (cd_usuario)
		REFERENCES usuario(cd_usuario),

	PRIMARY KEY (cd_evento, cd_usuario)
);

# Descomente a linha abaixo e execute para habilitar a conexão remota do banco
# GRANT ALL PRIVILEGES ON *.* to root@'%' identified by 'root';