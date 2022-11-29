USE maiscultura;

DELIMITER $$

DROP PROCEDURE IF EXISTS ListarUsuarios$$
CREATE PROCEDURE ListarUsuarios()
BEGIN
	SELECT
		u.cd_usuario "@",
		tu.nm_tipo_usuario "Tipo",
		u.sg_sexo "Sexo",
		u.nm_usuario "Nome",
		u.nm_email "Email",
		u.cd_senha "Senha",
		u.nm_documento "Documento",
		u.dt_nascimento "Nascimento"
	FROM usuario u
	JOIN tipo_usuario tu
		ON u.cd_tipo_usuario = tu.cd_tipo_usuario;
END$$

DROP PROCEDURE IF EXISTS ListarEventos$$
CREATE PROCEDURE ListarEventos()
BEGIN
	SELECT
		e.cd_evento "Codigo",
		e.cd_responsavel "@",
		e.nm_titulo "Titulo",
		e.ds_local "Local",
		e.ds_evento "Descricao",
		i.nm_imagem "Imagem"
	FROM evento e
		JOIN imagem_evento ie
			ON ie.cd_evento = e.cd_evento
		JOIN imagem i
			ON i.cd_imagem = ie.cd_imagem
	GROUP BY e.cd_evento;
END$$

DROP PROCEDURE IF EXISTS ListarCategorias$$
CREATE PROCEDURE ListarCategorias()
BEGIN
	SELECT
		cd_categoria "Codigo",
		nm_categoria "Nome"
	FROM categoria;
END$$

DROP PROCEDURE IF EXISTS MediaAvaliacao$$
CREATE PROCEDURE MediaAvaliacao( pEvento INT )
BEGIN
	SELECT 
		ROUND(AVG(qt_estrela), 1) "Média"
	FROM avaliacao 
	WHERE cd_evento = pEvento;
END$$

DROP PROCEDURE IF EXISTS BuscarDiasEvento$$
CREATE PROCEDURE BuscarDiasEvento(pEvento INT)
BEGIN
	SELECT
		de.cd_evento "CodigoEvento",
		de.dt_dia "Data",
		de.hr_inicial "Inicio",
		de.hr_final "Fim"
	FROM dia_evento de
	WHERE cd_evento = pEvento;
END$$

DROP PROCEDURE IF EXISTS ListarPreferenciasUsuario$$
CREATE PROCEDURE ListarPreferenciasUsuario(pCodigo VARCHAR(20))
BEGIN
	SELECT
		p.cd_categoria "CodigoCategoria",
		p.cd_usuario "@",
		c.nm_categoria "Nome"
	FROM preferencia p
	JOIN evento_categoria ce
		ON p.cd_categoria = ce.cd_categoria
	JOIN categoria c
		ON p.cd_categoria = c.cd_categoria
	WHERE p.cd_usuario = pCodigo
	GROUP BY c.nm_categoria;
END$$

DROP PROCEDURE IF EXISTS BuscarCategoriasEvento$$
CREATE PROCEDURE BuscarCategoriasEvento(pEvento INT)
BEGIN
	SELECT ce.cd_evento "CodigoEvento",
    ce.cd_categoria "CodigoCategoria",
    c.nm_categoria "Nome"
    FROM evento_categoria ce
    JOIN categoria c
    ON c.cd_categoria = ce.cd_categoria
    WHERE ce.cd_evento = pEvento;
END$$

DROP PROCEDURE IF EXISTS BuscarUsuario$$
CREATE PROCEDURE BuscarUsuario(pCodigo VARCHAR(20))
BEGIN
	SELECT 
		u.cd_usuario "@",
		tu.nm_tipo_usuario "Tipo",
		u.sg_sexo "Sexo",
		u.nm_usuario "Nome",
		u.nm_email "Email",
		u.cd_senha "Senha",
		u.nm_documento "Documento",
		u.dt_nascimento "Nascimento"
	FROM 
		usuario u
		INNER JOIN tipo_usuario tu ON u.cd_tipo_usuario = tu.cd_tipo_usuario
	WHERE 
		cd_usuario = pCodigo;
END$$

DROP PROCEDURE IF EXISTS BuscarLogin$$
CREATE PROCEDURE BuscarLogin(pCodigo VARCHAR(50), pSenha VARCHAR(35))
BEGIN
	SELECT
		u.cd_usuario "@",
		tu.nm_tipo_usuario "Tipo",
		u.sg_sexo "Sexo",
		u.nm_usuario "Nome",
		u.nm_email "Email",
		u.cd_senha "Senha",
		u.nm_documento "Documento",
		u.dt_nascimento "Nascimento"
	FROM usuario u
	INNER JOIN tipo_usuario tu ON u.cd_tipo_usuario = tu.cd_tipo_usuario
	WHERE 
		nm_email = pCodigo
		AND cd_senha  = md5(pSenha) 
	OR 
		cd_usuario = pCodigo
		AND cd_senha  = md5(pSenha);
END$$

DROP PROCEDURE IF EXISTS BuscarEvento$$
CREATE PROCEDURE BuscarEvento(pCodigo INT)
BEGIN
	SELECT
		cd_evento "Codigo",
		cd_responsavel "@",
		nm_titulo "Titulo",
		ds_local "Local",
		ds_evento "Descricao"
	FROM evento
	WHERE 
		cd_evento = pCodigo;
END$$

DROP PROCEDURE IF EXISTS BuscarEventoUsuario$$
CREATE PROCEDURE BuscarEventoUsuario(pCodigo VARCHAR(20))
BEGIN
	SELECT
		cd_evento "Codigo",
		cd_responsavel "@",
		nm_titulo "Titulo",
		ds_local "Local",
		ds_evento "Descricao"
	FROM evento
	WHERE  
		cd_responsavel = pCodigo;
END$$

DROP PROCEDURE IF EXISTS BuscarEventoCategoria$$
CREATE PROCEDURE BuscarEventoCategoria(pCat VARCHAR(20))
BEGIN
	SELECT
		e.cd_evento "Codigo",
		e.cd_responsavel "@",
		e.nm_titulo "Titulo",
		e.ds_local "Local",
		e.ds_evento "Descricao"
	FROM 
		evento e
		JOIN evento_categoria ec ON (ec.cd_evento = e.cd_evento)
		JOIN categoria c ON (ec.cd_categoria = c.cd_categoria)
	WHERE  
		c.nm_categoria = pCat;
END$$

DROP PROCEDURE IF EXISTS CadastrarUsuario$$
CREATE PROCEDURE CadastrarUsuario(
	pCodigo varchar(20), 
	pTipo int, 
	pSigla varchar(3), 
	pNome varchar(100), 
	pEmail varchar(50), 
	pSenha varchar(35), 
	pDocumento varchar(15), 
	pNascimento date)
BEGIN
	INSERT INTO usuario VALUES 
	( 
		pCodigo,
		pTipo, 
		pSigla, 
		pNome, 
		pEmail, 
		md5(pSenha), 
		pDocumento, 
		pNascimento 
	);
END$$

DROP PROCEDURE IF EXISTS CadastrarEvento$$
CREATE PROCEDURE CadastrarEvento(pCodigo INT, pResponsavel VARCHAR(20), pNome VARCHAR(140), pLocal TEXT, pDescricao TEXT)
BEGIN
	INSERT INTO evento VALUES (pCodigo, pResponsavel, pNome, pLocal, pDescricao);
END$$

DROP PROCEDURE IF EXISTS ListarEventosFeed$$
CREATE PROCEDURE ListarEventosFeed( pUsuario VARCHAR(20) )
BEGIN
	SELECT 
		e.cd_evento "Codigo",
		u.nm_usuario "Nome",
		e.cd_responsavel "@",
		e.nm_titulo "Titulo", 
		e.ds_local "Local",
        e.ds_evento "Descricao",
		GROUP_CONCAT(" ", c.nm_categoria) "Categorias",
		MIN(de.dt_dia) "Inicio",
		MAX(de.dt_dia) "Fim",
		MIN(de.hr_inicial) "Horario",
		i.nm_imagem "Imagem"
	FROM evento e 
	JOIN usuario u ON (u.cd_usuario = e.cd_responsavel)
	JOIN evento_categoria ce ON (ce.cd_evento = e.cd_evento)
	JOIN categoria c ON (c.cd_categoria = ce.cd_categoria)
	JOIN dia_evento de ON (e.cd_evento = de.cd_evento)
	JOIN imagem_evento ie ON (ie.cd_evento = e.cd_evento)
	JOIN imagem i ON (i.cd_imagem = ie.cd_imagem)
	WHERE e.cd_evento IN (
		SELECT cd_evento FROM evento_categoria WHERE cd_categoria IN (
			SELECT cd_categoria FROM preferencia WHERE cd_usuario = pUsuario
		)
	)
	GROUP BY e.cd_evento
	ORDER BY de.dt_dia;
END$$

DROP PROCEDURE IF EXISTS ListarEventosFeedDeslogado$$
CREATE PROCEDURE ListarEventosFeedDeslogado()
BEGIN
	SELECT 
		e.cd_evento "Codigo",
		u.nm_usuario "Nome",
		e.cd_responsavel "@",
		e.nm_titulo "Titulo", 
		e.ds_local "Local",
        e.ds_evento "Descricao",
		GROUP_CONCAT(" ", c.nm_categoria) "Categorias",
		DATE_FORMAT(MIN(de.dt_dia), "%d/%m/%Y") "Inicio",
		DATE_FORMAT(MAX(de.dt_dia), "%d/%m/%Y") "Fim",
		MIN(de.hr_inicial) "Horario",
		i.nm_imagem "Imagem"
	FROM evento e 
	JOIN usuario u ON (u.cd_usuario = e.cd_responsavel)
	JOIN evento_categoria ce ON (ce.cd_evento = e.cd_evento)
	JOIN categoria c ON (c.cd_categoria = ce.cd_categoria)
	JOIN dia_evento de ON (e.cd_evento = de.cd_evento)
	JOIN imagem_evento ie ON (ie.cd_evento = e.cd_evento)
	JOIN imagem i ON (i.cd_imagem = ie.cd_imagem)
	GROUP BY e.cd_evento
	ORDER BY de.dt_dia;
END$$

DROP PROCEDURE IF EXISTS filtrarEventos$$
CREATE PROCEDURE filtrarEventos ( 
	pCategoria INT, 
	pDia DATE, 
	pHora TIME, 
	pEstrelas INT, 
	pTitulo VARCHAR(140))
BEGIN
	SELECT 
		e.cd_evento "Codigo",
		u.nm_usuario "Nome",
		e.cd_responsavel "@",
		e.nm_titulo "Titulo", 
		e.ds_local "Local", 
		GROUP_CONCAT(" ", c.nm_categoria) "Categorias",
		DATE_FORMAT(MIN(de.dt_dia), "%d/%m/%Y") "Início",
		DATE_FORMAT(MAX(de.dt_dia), "%d/%m/%Y") "Fim",
		MIN(de.hr_inicial) "Horário",
		i.nm_imagem "Imagem"
	FROM evento e 
	JOIN usuario u ON (u.cd_usuario = e.cd_responsavel)
	JOIN evento_categoria ce ON (ce.cd_evento = e.cd_evento)
	JOIN categoria c ON (c.cd_categoria = ce.cd_categoria)
	JOIN dia_evento de ON (e.cd_evento = de.cd_evento)
	JOIN imagem_evento ie ON (ie.cd_evento = e.cd_evento)
	JOIN imagem i ON (i.cd_imagem = ie.cd_imagem)
	WHERE e.cd_evento IN (
		(SELECT e.cd_evento 
		FROM evento e
		JOIN evento_categoria ce ON (ce.cd_evento = e.cd_evento)
		JOIN dia_evento de ON (de.cd_evento = e.cd_evento)
		JOIN avaliacao a ON (a.cd_evento = e.cd_evento)
		WHERE 
			ce.cd_categoria = pCategoria OR 
			de.dt_dia = pDia OR 
			de.hr_inicial = pHora OR 
			a.qt_estrela > pEstrelas OR
			e.nm_titulo = pTitulo
		)
	)
	GROUP BY e.cd_evento
	ORDER BY e.cd_evento;
END$$

DROP PROCEDURE IF EXISTS BuscarInformacoesEvento$$
CREATE PROCEDURE BuscarInformacoesEvento( pEvento INT )
BEGIN
	SELECT 
		e.nm_titulo "Titulo",
		e.cd_responsavel "@",
		GROUP_CONCAT(" ", c.nm_categoria) "Categorias",
		DATE_FORMAT(MIN(de.dt_dia), "%d/%m/%Y") "Dia",
		de.hr_inicial "Início",
		de.hr_final "Término",
		e.ds_local "Local",
		e.ds_evento "Descrição"
	FROM evento e
	JOIN evento_categoria ce ON (ce.cd_evento = e.cd_evento)
	JOIN categoria c ON (c.cd_categoria = ce.cd_categoria)
	JOIN dia_evento de ON (de.cd_evento = e.cd_evento)
	WHERE e.cd_evento = pEvento
	GROUP BY de.dt_dia;
END$$

DROP PROCEDURE IF EXISTS BuscarInteressesEvento$$
CREATE PROCEDURE BuscarInteressesEvento( pEvento INT )
BEGIN
	SELECT count(cd_usuario) "Interesses" FROM interesse WHERE cd_evento = pEvento;
END$$

DROP PROCEDURE IF EXISTS BuscarImagemEvento$$
CREATE PROCEDURE BuscarImagemEvento( pEvento INT )
BEGIN
	SELECT im.nm_imagem "Imagem"
	FROM imagem im
	JOIN imagem_evento ie ON (ie.cd_imagem = im.cd_imagem)
	WHERE ie.cd_evento = pEvento;
END$$

DROP PROCEDURE IF EXISTS BuscarAvaliacoesEvento$$
CREATE PROCEDURE BuscarAvaliacoesEvento( pEvento INT )
BEGIN
	SELECT 
		u.nm_usuario "Nome",
		a.cd_usuario "@",
		a.ds_avaliacao "Descricao",
		a.qt_estrela "Estrelas"
	FROM avaliacao a
	JOIN usuario u ON (u.cd_usuario = a.cd_usuario)
	WHERE a.cd_evento = pEvento;
END$$

DROP PROCEDURE IF EXISTS BuscarAvaliacoesUsuario$$
CREATE PROCEDURE BuscarAvaliacoesUsuario( pUsuario VARCHAR(20) )
BEGIN
	SELECT 
		u.nm_usuario "Nome",
		a.cd_usuario "@",
		a.ds_avaliacao "Descrição",
		a.qt_estrela "Estrelas",
		a.cd_evento "CodigoEvento"
	FROM avaliacao a
	JOIN usuario u ON (u.cd_usuario = a.cd_usuario)
	WHERE a.cd_usuario = pUsuario;
END$$

DROP PROCEDURE IF EXISTS BuscarAvaliacaoEventoUsuario$$
CREATE PROCEDURE BuscarAvaliacaoEventoUsuario( pEvento INT, pUsuario VARCHAR(20) )
BEGIN
	SELECT 
		u.nm_usuario "Nome",
		a.cd_usuario "@",
		a.ds_avaliacao "Descricao",
		a.qt_estrela "Estrelas"
	FROM avaliacao a
	JOIN usuario u ON (u.cd_usuario = a.cd_usuario)
	WHERE a.cd_evento = pEvento and a.cd_usuario = pUsuario;
END$$

DROP PROCEDURE IF EXISTS AlterarAvaliacao$$
CREATE PROCEDURE AlterarAvaliacao( pEvento INT, pUsuario VARCHAR(20), pDescricao TEXT, pEstrelas INT)
BEGIN
	UPDATE avaliacao
	SET 
		ds_avaliacao = pDescricao,
		qt_estrela = pEstrelas
	WHERE cd_evento = pEvento and cd_usuario = pUsuario;
END$$

DROP PROCEDURE IF EXISTS CadastrarAvaliacao$$
CREATE PROCEDURE CadastrarAvaliacao( 
	pUsuario VARCHAR(20), 
	pEvento INT, 
	pDescricao TEXT, 
	pEstrelas INT)
BEGIN
	INSERT INTO avaliacao VALUES ( pUsuario, pEvento, pDescricao, pEstrelas );
END$$

DROP PROCEDURE IF EXISTS eventosSalvos$$
CREATE PROCEDURE eventosSalvos ( pUsuario VARCHAR(20) )
BEGIN
	SELECT 
		e.cd_evento "Codigo",
		u.nm_usuario "Nome",
		e.cd_responsavel "@",
		e.nm_titulo "Titulo", 
		e.ds_local "Local", 
		GROUP_CONCAT(" ", c.nm_categoria) "Categorias",
		DATE_FORMAT(MIN(de.dt_dia), "%d/%m/%Y") "Inicio",
		DATE_FORMAT(MAX(de.dt_dia), "%d/%m/%Y") "Fim",
		MIN(de.hr_inicial) "Horario",
		i.nm_imagem "Imagem"
	FROM evento e 
	JOIN usuario u ON (u.cd_usuario = e.cd_responsavel)
	JOIN evento_categoria ce ON (ce.cd_evento = e.cd_evento)
	JOIN categoria c ON (c.cd_categoria = ce.cd_categoria)
	JOIN dia_evento de ON (e.cd_evento = de.cd_evento)
	JOIN imagem_evento ie ON (ie.cd_evento = e.cd_evento)
	JOIN imagem i ON (i.cd_imagem = ie.cd_imagem)
	WHERE e.cd_evento IN (SELECT cd_evento FROM salvar WHERE cd_usuario = pUsuario)
	GROUP BY e.cd_evento
	ORDER BY e.cd_evento;
END$$

DROP PROCEDURE IF EXISTS MaxCodigoEvento$$
CREATE PROCEDURE MaxCodigoEvento()
BEGIN
	SELECT
		MAX(cd_evento) "Max" 
	FROM evento;
END$$

DROP PROCEDURE IF EXISTS CadastrarPreferencia$$
CREATE PROCEDURE CadastrarPreferencia(pCategoria INT, pUsuario VARCHAR(20))
BEGIN
	INSERT INTO preferencia VALUES
    (pCategoria, pUsuario);
END$$

DROP PROCEDURE IF EXISTS AlterarPreferencia$$
CREATE PROCEDURE AlterarPreferencia(pCategoria INT, pUsuario VARCHAR(20))
BEGIN
	IF pCategoria NOT IN (SELECT cd_categoria FROM preferencia WHERE cd_usuario = pUsuario)
	THEN
		INSERT INTO preferencia VALUES (pCategoria, pUsuario);
	END IF;
END$$

DROP PROCEDURE IF EXISTS AlterarEvento$$
CREATE PROCEDURE AlterarEvento(pCodigo INT, pResponsavel VARCHAR(20), pNome VARCHAR(140), pLocal TEXT, pDescricao TEXT)
BEGIN
	UPDATE evento
		SET 
			cd_responsavel = pResponsavel,
			nm_titulo = pNome,
			ds_local = pLocal,
			ds_evento = pDescricao
	WHERE cd_evento = pCodigo;
END$$

DROP PROCEDURE IF EXISTS AlterarCategoriaEvento$$
CREATE PROCEDURE AlterarCategoriaEvento(pCodigo INT, pCategoria INT)
BEGIN
	UPDATE evento_categoria
		SET 
			cd_categoria = pCategoria
	WHERE cd_evento = pCodigo;
END$$

DROP PROCEDURE IF EXISTS AlterarDiaEvento$$
CREATE PROCEDURE AlterarDiaEvento(pCodigo INT, pData DATE, pInicial TIME, pFinal TIME)
BEGIN
	UPDATE dia_evento
		SET 
			dt_dia = pData,
			hr_inicial = pInicial,
			hr_final = pFinal
	WHERE cd_evento = pCodigo;
END$$

DROP PROCEDURE IF EXISTS CadastrarCategoriaEvento$$
CREATE PROCEDURE CadastrarCategoriaEvento(pEvento INT, pCategoria INT)
BEGIN
	INSERT INTO evento_categoria VALUES
    (pCategoria, pEvento);
END$$

DROP PROCEDURE IF EXISTS CadastrarDiaEvento$$
CREATE PROCEDURE CadastrarDiaEvento(pEvento INT, pDia DATE, pInicio TIME, pFim TIME)
BEGIN
	INSERT INTO dia_evento VALUES
    (pEvento, pDia, pInicio, pFim);
END$$

DROP PROCEDURE IF EXISTS BuscarMediaEvento$$
CREATE PROCEDURE BuscarMediaEvento(pEvento int)
BEGIN
	SELECT
		ROUND(AVG(a.qt_estrela), 1) as "Media"
	FROM evento e
	JOIN avaliacao a ON (e.cd_evento = a.cd_evento)
	WHERE e.cd_evento = pEvento;
END$$

DROP PROCEDURE IF EXISTS BuscarMediaCriador$$
CREATE PROCEDURE BuscarMediaCriador(pCodigo VARCHAR(20))
BEGIN
	DECLARE soma DOUBLE DEFAULT 0.0;
	DECLARE codigoEvento INT DEFAULT 0;
	DECLARE media INT DEFAULT 0;
	DECLARE contador INT DEFAULT 0;
	DECLARE parar INT DEFAULT 0;

	DECLARE dados CURSOR FOR 
		SELECT cd_evento 
		FROM evento 
		WHERE cd_responsavel = pCodigo 
		ORDER BY cd_evento;
	
	DECLARE CONTINUE HANDLER FOR NOT FOUND
		SET parar = 1;

	OPEN dados;

	todos:LOOP
		FETCH dados INTO codigoEvento;

		IF (parar = 1) THEN
			LEAVE todos;
		END IF;

		SELECT
			ROUND(AVG(a.qt_estrela), 1) INTO media
		FROM evento e
		JOIN avaliacao a ON (e.cd_evento = a.cd_evento)
		WHERE e.cd_evento = codigoEvento;

		SET soma = soma + media;
		SET contador = contador + 1;
	END LOOP;
	
	SET soma = soma / contador;
	
	SELECT soma;
END$$

DROP PROCEDURE IF EXISTS AlterarSenha$$
CREATE PROCEDURE AlterarSenha(pUsuario VARCHAR(20), pSenha VARCHAR(100))
BEGIN
	UPDATE usuario
		SET cd_senha = MD5(pSenha)
	WHERE cd_usuario = pUsuario;
END$$

DROP PROCEDURE IF EXISTS ListarDenuncias$$
CREATE PROCEDURE ListarDenuncias()
BEGIN
	SELECT
		d.cd_denuncia "CodigoDenuncia",
		d.cd_evento "CodigoEvento",
		d.cd_usuario "@",
		DATE_FORMAT(d.dt_denuncia, "%d/%m/%Y") "Data",
		d.hr_denuncia "Hora",
		lm.nm_motivo "Motivo",
		m.cd_motivo "CodigoMotivo",
		m.ds_denuncia "Descricao"
	FROM denuncia d
	JOIN motivo m ON d.cd_denuncia = m.cd_denuncia
	JOIN lista_motivo lm ON m.cd_motivo = lm.cd_motivo;
END$$

DROP PROCEDURE IF EXISTS BuscarDenuncia$$
CREATE PROCEDURE BuscarDenuncia(pCodigo INT)
BEGIN
	SELECT
		d.cd_denuncia "CodigoDenuncia",
		d.cd_evento "CodigoEvento",
		d.cd_usuario "@",
		DATE_FORMAT(d.dt_denuncia, "%d/%m/%Y") "Data",
		d.hr_denuncia "Hora",
		lm.nm_motivo "Motivo",
		m.ds_denuncia "Descricao",
		lm.cd_motivo "CodigoMotivo"
	FROM denuncia d
	JOIN motivo m ON d.cd_denuncia = m.cd_denuncia
	JOIN lista_motivo lm ON m.cd_motivo = lm.cd_motivo
	WHERE d.cd_denuncia = pCodigo;
END$$

DROP PROCEDURE IF EXISTS BuscarDenunciasUsuario$$
CREATE PROCEDURE BuscarDenunciasUsuario(pCodigo VARCHAR(20))
BEGIN
	SELECT
		d.cd_denuncia "CodigoDenuncia",
		d.cd_evento "CodigoEvento",
		d.cd_usuario "@",
		DATE_FORMAT(d.dt_denuncia, "%d/%m/%Y") "Data",
		d.hr_denuncia "Hora",
		lm.nm_motivo "Descricao"
	FROM denuncia d
	JOIN motivo m ON d.cd_denuncia = m.cd_denuncia
	JOIN lista_motivo lm ON m.cd_motivo = lm.cd_motivo
	WHERE d.cd_usuario = pCodigo;
END$$

DROP PROCEDURE IF EXISTS BuscarDenunciasEvento$$
CREATE PROCEDURE BuscarDenunciasEvento(pEvento INT)
BEGIN
	SELECT
		d.cd_denuncia "CodigoDenuncia",
		d.cd_evento "CodigoEvento",
		d.cd_usuario "@",
		DATE_FORMAT(d.dt_denuncia, "%d/%m/%Y") "Data",
		d.hr_denuncia "Hora",
		lm.nm_motivo "Descricao"
	FROM denuncia d
	JOIN motivo m ON d.cd_denuncia = m.cd_denuncia
	JOIN lista_motivo lm ON m.cd_motivo = lm.cd_motivo
	WHERE d.cd_evento = pEvento;
END$$

DROP PROCEDURE IF EXISTS BuscarDenunciasUsuarioEvento$$
CREATE PROCEDURE BuscarDenunciasUsuarioEvento(pCodigo VARCHAR(20), pEvento INT)
BEGIN
	SELECT
		d.cd_denuncia "CodigoDenuncia",
		d.cd_evento "CodigoEvento",
		d.cd_usuario "@",
		DATE_FORMAT(d.dt_denuncia, "%d/%m/%Y") "Data",
		d.hr_denuncia "Hora",
		lm.nm_motivo "Descricao"
	FROM denuncia d
	JOIN motivo m ON d.cd_denuncia = m.cd_denuncia
	JOIN lista_motivo lm ON m.cd_motivo = lm.cd_motivo
	WHERE d.cd_usuario = pCodigo;
END$$

DROP PROCEDURE IF EXISTS DeletarUsuario$$
CREATE PROCEDURE DeletarUsuario(pCodigo VARCHAR(20))
BEGIN
	DELETE FROM equipe_evento WHERE cd_usuario = pCodigo;
	
	CALL DeletarDenunciaUsuario(pCodigo);

	DELETE FROM preferencia WHERE cd_usuario = pCodigo;
	DELETE FROM salvar WHERE cd_usuario = pCodigo;
	DELETE FROM interesse WHERE cd_usuario = pCodigo;
	DELETE FROM avaliacao WHERE cd_usuario = pCodigo;
	DELETE FROM evento WHERE cd_responsavel = pCodigo;
	DELETE FROM usuario WHERE cd_usuario = pCodigo;
END$$

DROP PROCEDURE IF EXISTS DeletarEvento$$
CREATE PROCEDURE DeletarEvento(pCodigo INT)
BEGIN
	DELETE FROM imagem_evento WHERE cd_evento = pCodigo;
	DELETE FROM avaliacao WHERE cd_evento = pCodigo;
	DELETE FROM dia_evento WHERE cd_evento = pCodigo;
	DELETE FROM interesse WHERE cd_evento = pCodigo;
	DELETE FROM salvar WHERE cd_evento = pCodigo;
	DELETE FROM evento_categoria WHERE cd_evento = pCodigo;

	CALL DeletarDenunciaEvento(pCodigo);

	DELETE FROM equipe_evento WHERE cd_evento = pCodigo;
	DELETE FROM evento WHERE cd_evento = pCodigo;
END$$

DROP PROCEDURE IF EXISTS DeletarDenuncia$$
CREATE PROCEDURE DeletarDenuncia(pCodigo INT)
BEGIN
	DELETE FROM motivo where cd_denuncia = pCodigo;
	DELETE FROM denuncia where cd_denuncia = pCodigo;
END$$

DROP PROCEDURE IF EXISTS DeletarDenunciaEvento$$
CREATE PROCEDURE DeletarDenunciaEvento(pCodigo INT)
BEGIN
	DECLARE codigo INT DEFAULT 0;

	SELECT d.cd_denuncia INTO codigo
	FROM evento e 
	JOIN denuncia d ON (e.cd_evento = d.cd_evento) 
	WHERE e.cd_evento = pCodigo;

	CALL DeletarDenuncia(codigo);
END$$

DROP PROCEDURE IF EXISTS DeletarDenunciaUsuario$$
CREATE PROCEDURE DeletarDenunciaUsuario(pCodigo VARCHAR(20))
BEGIN
	DECLARE codigo INT DEFAULT 0;

	SELECT cd_denuncia INTO codigo
	FROM denuncia
	WHERE cd_usuario = pCodigo;

	CALL DeletarDenuncia(codigo);
END$$

DROP PROCEDURE IF EXISTS BuscarInteressesEvento$$
CREATE PROCEDURE BuscarInteressesEvento(pEvento INT)
BEGIN
	SELECT COUNT(cd_evento) "Soma" FROM interesse WHERE cd_evento = pEvento;
END$$

DROP PROCEDURE IF EXISTS DeletarAvaliacao$$
CREATE PROCEDURE DeletarAvaliacao(
	pUsuario VARCHAR(20),
	pEvento INT
)
BEGIN
	DELETE FROM denuncia WHERE cd_evento = pEvento AND cd_usuario = pUsuario;
END$$

DROP PROCEDURE IF EXISTS AdicionarInteresse$$
CREATE PROCEDURE AdicionarInteresse(
	pUsuario VARCHAR(20),
	pEvento INT
)
BEGIN
	INSERT INTO interesse VALUES (pEvento, pUsuario);
END$$

DROP PROCEDURE IF EXISTS RemoverInteresse$$
CREATE PROCEDURE RemoverInteresse(
	pUsuario VARCHAR(20),
	pEvento INT
)
BEGIN
	DELETE FROM interesse WHERE cd_evento = pEvento AND cd_usuario = pUsuario;
END$$

DROP PROCEDURE IF EXISTS AdicionarSalvo$$
CREATE PROCEDURE AdicionarSalvo ( pUsuario VARCHAR(20), pEvento INT)
BEGIN
	INSERT INTO salvar VALUES ( pEvento, pUsuario);
END$$

DROP PROCEDURE IF EXISTS RemoverSalvo$$
CREATE PROCEDURE RemoverSalvo ( pUsuario VARCHAR(20), pEvento INT)
BEGIN
	DELETE FROM salvar WHERE cd_evento = pEvento AND cd_usuario = pUsuario;
END$$

DROP PROCEDURE IF EXISTS BuscarSalvoUsuarioEvento$$
CREATE PROCEDURE BuscarSalvoUsuarioEvento ( pUsuario VARCHAR(20), pEvento INT)
BEGIN
	SELECT * FROM salvar WHERE cd_evento = pEvento AND cd_usuario = pUsuario;
END$$

DELIMITER ;
