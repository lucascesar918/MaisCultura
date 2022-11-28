USE maiscultura;

INSERT INTO sexo VALUES
("M", "Masculino"),
("F", "Feminino"),
("NO", "Desejo não informar");

INSERT INTO tipo_usuario VALUES
(1, "Administrador"),
(2, "Usuário Comum"),
(3, "Criador de Eventos"),
(4, "Empresa");

INSERT INTO categoria VALUES
(1, "Música"),
(2, "Pintura"),
(3, "Literatura"),
(4, "Artesanato"),
(5, "Dança"),
(6, "Teatro"),
(7, "Cinema"),
(8, "Artes Plásticas"),
(9, "Culinária"),
(10, "Esporte"),
(11, "Show"),
(12, "Festival"),
(13, "Exposição"),
(14, "Sarau"),
(15, "Campeonato"),
(16, "Escolar"),
(17, "Artes Visuais"),
(18, "Manifestação"),
(19, "Workshop"),
(20, "Entretenimento"),
(21, "Arte Cênica");

INSERT INTO lista_motivo VALUES
(1, "Má organização"),
(2, "Má localização"),
(3, "Local inapropriado para evento"),
(4, "Promessa não cumprida"),
(5, "Falta de segurança"),
(6, "Fraude"),
(7, "Outros motivo");

INSERT INTO imagem VALUES
(1, "https://encrypted-tbn2.gstatic.com/images?q=tbn:ANd9GcSuvFmTrdPETf9BXuXjAiPJc9SB_UMH2K6awZnW54m_QK7RtKUu"),
(2, "https://p2.trrsf.com/image/fget/cf/648/0/images.terra.com/2022/08/07/1164336420-1659894171158.jpg"),
(3, "https://diplomatique.org.br/wp-content/uploads/2022/08/cota_visibilidadenegra.jpg"),
(4, "https://www.ccpnet.com.br/Arquivos/Noticias/2018516_05_09_noticia_site_bocce_sinuca_truco-01.jpg"),
(5, "https://i.ytimg.com/vi/oO2LKIjB6zY/maxresdefault.jpg"),
(6, "https://miro.medium.com/max/1024/1*ddjWqVJPF8CuX-WUKh1ufg.jpeg"),
(7, "https://www.cultura930.com.br/wp-content/uploads/2021/06/image_processing20200201-29235-p5jz15.jpeg"),
(8, "https://revistaadega.uol.com.br/media/wines_of_chile_tasting.jpg"),
(9, "http://andysawyer.com/wp-content/uploads/2017/04/SWMRS-TITLE-2.jpg"),
(10, "https://prefeitura.pbh.gov.br/sites/default/files/styles/slideshow/public/noticia/img/2017-04/Exposi%C3%A7%C3%A3o%20Elefantes%20-%20Maria%20In%C3%AAz%20Ribeiro%20%283%29.jpg?itok=JknOJ_Mu"),
(11, "https://www.costerus.com.br/wp-content/uploads/2020/06/Pintura_de_paisagem_e_suas_diversas_fases_na_hist%C3%B3ria_1.jpg");

INSERT INTO usuario VALUES
( "jota.carlos04", 1, "M", "João Carlos Tavares", "joao.tavares@gmail.com", md5("joaoc123"), "94604326622", "2004/04/10" ),
( "lorenzo.daniel", 1, "M", "Lorenzo Souza Daniel", "lorenzo.adm@gmail.com", md5("lorenzo123"), "52738745806", "2005/06/03" ),
( "lucas.serio", 1, "M", "Lucas César Freitas", "lucas.serio@gmail.com", md5("lucas123"), "58444561223", "2004/08/03" ),
( "joao.pedro", 1, "M", "João Pedro Soares Franca", "joao.franca@gmail.com", md5("joaop123"), "84913505270", "2004/03/27" ),
( "murilo.reiss", 1, "M", "Murilo Reis de Jesus", "murilo.jesus@gmail.com", md5("murilo123"), "38686390633", "2005/01/25" ),
( "arthur.niilista", 1, "M", "Arthur Gomes", "arthur.gomes@gmail.com", md5("arthur123"), "65913138503", "2005/01/14"),
( "camix.santana", 2, "F", "Camila Santana Gomes", "camila.gomes@gmail.com", md5("camila123"), null, "2004/09/04"),
( "clara.barriento", 2, "F", "Clara da Silva Barriento", "clara.barriento@gmail.com", md5("clara123"), null, "2004/06/12"),
( "japafkt", 2, "M", "Felipe Kenji Toyama", "japafkt@gmail.com", md5("kenji123"), null, "2005/03/22"),
( "barbarafavilla", 3, "F", "Bárbara Favilla Pera", "barbara.favilla@gmail.com", md5("barbara123"), "69522359300", "2004/12/28"),
( "allan.fagner", 3, "M", "Allan Fagner", "allan.fagner@gmail.com", md5("fagner123"), "27249986007", "2005/04/21"),
( "adriano.fraga", 3, "M", "Adriano Ribeiro Fraga", "adriano.fraga@gmail.com", md5("adriano123"), "13053883562", "2005/08/23"),
( "3n1", 4, null, "3N1", "empresa@3n1.com.br", md5("3n1123"), "07395478000107", "2020/02/01"),
( "2n1", 4, null, "2N1", "empresa@2n1.com.br", md5("2n1123"), "47431506000119", "2021/02/01"),
( "1n1", 4, null, "1N1", "empresa@1n1.com.br", md5("1n1123"), "31971177000169", "2022/02/01");

INSERT INTO evento VALUES
(1, "barbarafavilla", "Interclasse: Ablas x Etecaf", 'Sesc Santos', 'O tão esperado interclasse entre as duas escolas: Ablas e Etecaf. O evento é aberto e gratuito! Esteja lá representando sua escola!'),
(2, "3n1", "Apresentação da Camisa Oficial da Turma", 'Sala 2, Prédio João Octávio dos Santos, Etec Aristóteles Ferreira na Av. Epitácio Pessoa', 'Apresentação oficial da turma 3N1 de sua camisa oficial em seu produto final, junto do brasão da sala entre outros diversos produtos!'),
(3, "allan.fagner", "Protesto em Defesa das Cotas Raciais", 'Avenida Paulista, em frente ao MASP', 'Protesto organizado pelo movimento BLM em defesa das cotas raciais e em repúdio à PL 9999/22! Vamos juntos à luta!'),
(4, "adriano.fraga", "Oficina das Artes dos Bares: Baralho e Sinuca", 'Casa do Adriano, nºXX', 'Em formato de oficina, o Prof. Dr. Adriano Ribeiro Fraga apresentará, de maneira gratuita e livre, uma oficina ensinando todas as mais importantes maneiras de se jogar dois dos mais importantes jogos de bares: Baralho e Sinuca.'),
(5, "2n1", "Hamlet no Mundo Contemporâneo", 'Sala 1, Etec Aristóteles Ferreira', 'Com um elenco magnífico, a turma de Desenvolvimento de Sistemas, 2N1 da Etecaf apresentará de forma aberta e gratuita sua própria interpretação da peça teatral Hamlet, de William Shakespeare, com um toque e olhar dos dias modernos.'),
(6, "1n1", "Famigerada Entropia", 'Sala X, Etec Aristóteles Ferreira', 'A OS1N1(Orquestra Sinfônica do 1N1) convida todas as pessoas com interesse para apreciar sua apresentação inédita de seu novo soneto: "A Famigerada Entropia"!'),
(7, "allan.fagner", "Slam e Poetria: Versos Sujos e Desconexos", 'Parque Ibirapuera', 'Com a força de todos, e a magia das letras e palavras sujas do povo, todos que tenham algo a falar são convocados para revelar seus versos e poesias!'),
(8, "adriano.fraga", "Degustação de Vinhos Chilenos: Arte Centenária", 'Sesc, segundo andar', 'De maneira aberta e gratuita à todos, será ministrada uma aula permeando diversos assuntos e bases para uma melhor degustação e apreciação de vinhos, em especial, os chilenos.'),
(9, "barbarafavilla", "DRKN SWMRS: Fita #1", 'Teatro 1, Sesc Santos', 'A primeira apresentação aberta e gratuita da banda de indie rock caiçara DRNK SWMRS, apresentando, com orgulho sua arte: Fita#1'),
(10, "allan.fagner", "Vida e Sangue Seco: Diversas Pinturas", 'Sesc Santos, Saguão Principal', 'De maneira aberta e gratuita, o Sesc Santos sedia a exposição "Vida e Sangue Seco:Diversas Pinturas", um grupo de 20 pinturas que juntas contam histórias relacionadas ao cotidiano brasileiro e suas culturas próprias.');


INSERT INTO imagem_evento VALUES
(1, 1),
(2, 2),
(3, 3),
(4, 4),
(5, 5),
(6, 6),
(7, 7),
(8, 8),
(9, 9),
(10, 10),
(10, 11);

/*Se um evento tiver dois horários no mesmo dia, o banco não aceita que tenha duas entradas com duas primary keys (cd_evento e dt_evento) iguais. */
INSERT INTO dia_evento VALUES
(1, "2022/10/08", "16:00:00", "22:00:00"),
(2, "2022/11/08", "15:00:00", "23:00:00"),
(3, "2022/12/08", "14:00:00", "19:00:00"),
(4, "2022/09/08", "15:30:00", "21:00:00"),
(4, "2022/09/09", "14:00:00", "20:00:00"),
(4, "2022/09/10", "16:00:00", "21:00:00"),
(5, "2022/08/20", "14:30:00", "16:00:00"),
(6, "2022/10/22", "14:30:00", "17:10:00"),
(7, "2022/12/01", "13:30:00", "17:00:00"),
(8, "2022/08/10", "15:00:00", "18:30:00"),
(8, "2022/08/11", "15:30:00", "19:00:00"),
(9, "2022/12/10", "19:00:00", "23:00:00"),
(9, "2022/12/11", "17:30:00", "21:30:00"),
(10, "2022/09/10", "08:00:00", "19:00:00"),
(10, "2022/09/11", "07:30:00", "21:00:00");

/*Não dá pra um mesmo usuário fazer mais de uma avaliação sobre um mesmo evento. */
INSERT INTO avaliacao VALUES
( "japafkt", 1, "A partida foi super acirrada e absolutamente incrível. A organização do evento que fez com que tantas pessoas pudessem caber numa arena foi surpreendente.", 5),
("camix.santana", 2, "Incrível", 5),
("clara.barriento", 3, "Bom", 4),
("japafkt", 4, "Mediano", 3),
("camix.santana", 5, "A classe foi maravilhosa ao apresentar essa visão moderna de uma obra tão complexa.", 5),
("clara.barriento", 5, "A aula foi incrível	e o professor é obviamente um homem muito sábio e inteligente. Aprendi muito e vou levar esses conhecimentos para a vida.", 4),
("japafkt", 6, "Foi simplesmente lindo. A orquestra é maravilhosa e essa nova composição é incrível de ouvir. Todos os instrumentos foram perfeitos.", 5),
("camix.santana", 7, "Mediano", 3),
("clara.barriento", 8, "Muito Bom", 5),
("japafkt", 9, "Nunca tinha ouvido falar da banda, porém, por ser indie rock local, resolvi ir ver. Foi uma das melhores ideias! As músicas são incríveis e a sensação foi maravilhosa.", 4),
("camix.santana", 10, "Ruim", 2);

INSERT INTO interesse VALUES
(1, "camix.santana"),
(1, "clara.barriento"),
(1, "japafkt"),
(2, "camix.santana"),
(2, "clara.barriento"),
(2, "japafkt"),
(2, "allan.fagner"),
(2, "adriano.fraga"),
(3, "camix.santana"),
(3, "clara.barriento"),
(3, "allan.fagner"),
(4, "clara.barriento"),
(4, "allan.fagner"),
(9, "adriano.fraga"),
(5, "allan.fagner"),
(5, "japafkt"),
(6, "camix.santana"),
(6, "clara.barriento"),
(6, "japafkt"),
(7, "camix.santana"),
(7, "clara.barriento"),
(8, "camix.santana"),
(8, "clara.barriento"),
(9, "allan.fagner"),
(9, "japafkt"),
(10, "adriano.fraga"),
(10, "camix.santana"),
(10, "allan.fagner");

INSERT INTO salvar VALUES
(1, "allan.fagner"),
(1, "barbarafavilla"),
(2, "camix.santana"),
(2, "clara.barriento"),
(3, "adriano.fraga"),
(4, "japafkt"),
(4, "camix.santana"),
(4, "clara.barriento"),
(5, "allan.fagner"),
(5, "barbarafavilla"),
(5, "adriano.fraga"),
(5, "camix.santana"),
(6, "allan.fagner"),
(6, "barbarafavilla"),
(6, "adriano.fraga"),
(7, "clara.barriento"),
(7, "allan.fagner"),
(7, "barbarafavilla"),
(8, "adriano.fraga"),
(8, "japafkt"),
(9, "japafkt"),
(9, "camix.santana"),
(10, "camix.santana"),
(10, "clara.barriento"),
(10, "japafkt");

INSERT INTO evento_categoria VALUES
(1, 10),
(1, 15),
(1, 16),
(2, 16),
(2, 17),
(3, 18),
(4, 19),
(4, 20),
(5, 3),
(5, 6),
(5, 21),
(6, 1),
(6, 13),
(7, 3),
(7, 13),
(7, 14),
(8, 20),
(9, 1),
(9, 11),
(9, 17),
(10, 2),
(10, 8),
(10, 13);

INSERT INTO preferencia VALUES
(1, "camix.santana"),
(1, "clara.barriento"),
(1, "allan.fagner"),
(1, "barbarafavilla"),
(1, "adriano.fraga"),
(3, "camix.santana"),
(3, "clara.barriento"),
(3, "allan.fagner"),
(3, "barbarafavilla"),
(3, "adriano.fraga"),
(7, "camix.santana"),
(7, "clara.barriento"),
(7, "allan.fagner"),
(7, "barbarafavilla"),
(7, "adriano.fraga"),
(9, "camix.santana"),
(10, "camix.santana"),
(10, "japafkt"),
(10, "clara.barriento"),
(10, "allan.fagner"),
(10, "barbarafavilla"),
(10, "adriano.fraga");

INSERT INTO denuncia VALUES
(1, 3, "camix.santana", "2022/12/09", "08:34:00"),
(2, 2, "allan.fagner", "2022/11/08", "23:54:00"),
(3, 8, "japafkt", "2022/08/11", "17:30:00");

INSERT INTO motivo VALUES
(5, 1, "Houve uma falta de segurança e pessoal habilitado enorme no protesto. Um momento que deveria ser para exercer direitos, acabou virando aanrquia após a invasão da área do evento por pessaos contrárias aos temas apoiados! Não houve policiamento nenhum e teve muita agressão."),
(4, 2, "Prometeram que os participantes do evento ganhariam uma camisa grátis e 50% de desconto nos casacos, porém, na hora das compras, todos os vendedores estavam passando nos cartões os valores completos, sem desconto, e ninguém estava notando!"),
(3, 2, "O evento foi realizado em local completamente inapropriado. Além das promessas não cumpridas, não tinha espaço para todo mundo. Ficamos quase como um monte de sardinhas enlatadas."),
(7, 3, "Mesmo que o evento tenha sido muito bem feito e tenha aprendido muito, provavelmente não houve higienização completa dos copos ou garrafas, ou ainda tinha algum vinho podre, porque acabei com uma intoxicação alimentar logo após o evento.");

INSERT INTO equipe_evento VALUES
(1, "barbarafavilla"),
(2, "allan.fagner"),
(3, "3n1"),
(3, "allan.fagner"),
(4, "adriano.fraga"),
(5, "2n1"),
(6, "1n1"),
(7, "allan.fagner"),
(8, "adriano.fraga"),
(9, "barbarafavilla"),
(10, "allan.fagner");







 