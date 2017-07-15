/* BANCO DE DADOS PRINCIPAL */
CREATE DATABASE IF NOT EXISTS cidadaoalerta;
USE cidadaoalerta;

/* Tabela de usuários do sistema */
CREATE TABLE IF NOT EXISTS usuario(
	usuario_id integer AUTO_INCREMENT,			    /* Id do usuário */
	login varchar(50) NOT NULL DEFAULT '',	        /* Login do usuário */
	senha varchar(32) NOT NULL DEFAULT '',	        /* senha do usuário */
	CONSTRAINT cp_usuario PRIMARY KEY (usuario_id)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/* Tabela de usuários do sistema */
CREATE TABLE IF NOT EXISTS ocorrencia(
	ocorrencia_id integer AUTO_INCREMENT,			    /* Id do usuário */
	usuario_id integer DEFAULT 0,			    /* Id do usuário */
	tipo_ocorrencia integer DEFAULT 0,			    /* Id do usuário */
	tipo_item integer DEFAULT 0,			    /* Id do usuário */
	data datetime NOT NULL DEFAULT '1900-01-01 00:00:00',	        /* Login do usuário */
	descricao varchar(255) NOT NULL DEFAULT '',	        /* senha do usuário */
	latitude varchar(50) NOT NULL DEFAULT '',	        /* senha do usuário */
	longitude varchar(50) NOT NULL DEFAULT '',	        /* senha do usuário */
	CONSTRAINT cp_ocorrencia PRIMARY KEY (ocorrencia_id)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/* Tabela de usuários do sistema */
CREATE TABLE IF NOT EXISTS interacao(
	interacao_id integer AUTO_INCREMENT,			    /* Id do usuário */
	usuario_id integer DEFAULT 0,			            /* Id do usuário */
	ocorrencia_id integer DEFAULT 0,			        /* Id do usuário */
	data datetime NOT NULL DEFAULT '1900-01-01 00:00:00',	        /* Login do usuário */
	descricao varchar(255) NOT NULL DEFAULT '',	        /* senha do usuário */
	latitude varchar(50) NOT NULL DEFAULT '',	        /* senha do usuário */
	longitude varchar(50) NOT NULL DEFAULT '',	        /* senha do usuário */
	CONSTRAINT cp_interacao PRIMARY KEY (interacao_id)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

