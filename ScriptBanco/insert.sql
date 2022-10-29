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
(11, "Outros");

INSERT INTO lista_motivo VALUES
(1, "Má organização"),
(2, "Má localização"),
(3, "Local inapropriado para evento"),
(4, "Promessa não cumprida"),
(5, "Falta de segurança"),
(6, "Fraude"),
(7, "Outros motivo");

INSERT INTO imagem VALUES
(1, "https://c4.wallpaperflare.com/wallpaper/423/436/839/spirit-blossom-thresh-league-of-legends-thresh-league-of-legends-riot-games-hd-wallpaper-preview.jpg"),
(2, "https://i.pinimg.com/originals/32/a6/bf/32a6bfe7cbdbe088d5da489a2e40bfdf.jpg"),
(3, "https://images.hdqwalls.com/download/high-noon-senna-league-of-legends-x4-1920x1080.jpg"),
(4, "https://static.fandomspot.com/images/02/27321/00-featured-lol-original-vel-koz-skin-splash-image.jpg"),
(5, "data:image/jpeg;base64,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"),
(6, "https://www.teahub.io/photos/full/48-485080_dunkmaster-darius-lol-darius.jpg"),
(7, "data:image/jpeg;base64,/9j/4AAQSkZJRgABAQAAAQABAAD/2wCEAAoHCBYVFRgVFhUYGBgYHBgaGhoaGBgYGBwYGBgZGRgYGBgcIS4lHB4rIRoYJjgnKy8xNTU1GiQ7QDs0Py40NTEBDAwMEA8QHhISHDQhJCQ0NDQ0NDQ0NDQ0NDQ0NDQ0NDQ0NDQxNDQ0NDQ0NDQ0NDQ0NDE0NDQ0NDQ0NDQ0NDQxNP/AABEIAKgBLAMBIgACEQEDEQH/xAAbAAACAwEBAQAAAAAAAAAAAAACAwABBAUGB//EADcQAAIBAgUCBAQFAwUAAwAAAAECAAMRBBIhMUFRYQVxgZEiobHwBhMywdEUQuFSYnKi8SNDkv/EABgBAQEBAQEAAAAAAAAAAAAAAAEAAgME/8QAHhEBAQEBAQEBAQEBAQAAAAAAAAERAiExQWESgVH/2gAMAwEAAhEDEQA/APkYkliXOgTLJlhKvSS/Bg1MDLlkSykjeaC0sGEFkQSYqZZe2sIC0t0+ckbSqcS8RYoR6j0iFFob2INxxHRjKoliWFlhZFUJZVoaiFMiKsYsvIRboYX5Z59OnpA4E26/WEjaw2pWG0FaRMpU0U3m/DPMAQjeasOZuMV0leRhpeLpv7y6jsDfQg8cj+ZrWGXECYHE6FUb6TDVEzW4ykxqRdSXSOtgLmZLWyTBiUnUAsNdTMeJW+w++8bFHNtKj0ok3PTT1gMh2AgQKJTGNZbREoKkksCVNJUkuSSXLvKkghK1tRCepfca9Rp7wJJFYqGHTPt0gMLyUmsYG2w1GA3H33mv+kVxce4jERHT5f48xxMyUXQ3XjYqR8xNMfTmolQA2t9j+x7wXp/D5a/O9/2nWw9dXQo65X6EWzC+69weJlFLKxB4vf8AcSEtnjA1O/1/n9ol9BadR8IVf/blJB63O30mCstveZplKReu8plMs3jCbwJKrGBJQB6aRyC8SqoDZR0P/n32mhKpU2seL6ArfrbeOoYbM6L/AKmt72novFfCqdJsqAufyyWJ4NzmyjqFC2/5QrUrm1cIHQOqkAm2ZSGS9r6g2KeWszigF/Vp9J2/w1SS92HwP8JFyBvcEjpf1F9LT02I/B2HqEMHqJtemr/ASOdRf5w3/KzXz7GUwAv3pF0hPS/ifwhKbIUcHQoVuCykag26fwJxqdG03zdjHUxdBOYZN4wU9vT5wdt4sMNdtSJj3uek2VUzMAOdz9TBanuoGlt4FzXGs0YdbDTcwlw9z0AF2PAA3JnWPhhRGdvhGW+2pvtL+me+Rz6DZgdgLm3kBv8AWT8vN2AmnC+GuSAw+JrWUbhTtccE/TznR8TwCU0Ku2pA0AOt97W16e4lPWrMuPK1Kyg2XW3Tb/MFqt1vtwIzEKtjkQ2va5G3r1mVEJ8h96Qta5ltyEsISJeW4Ep34GgiuplR+gi7SSSYVJLkikkkhKt4JaJeMRIWXSMorEaS6wLTXVSZynSVilUhtHK5O0QYdOBdjANnXJezqcyE7hh0PINhcevBnXCpiULBbOmjDZh/kfyJ5im+UqRuDf2nbwOKRmD5jTqj/wCwC4Omzpsw+cWOoYqEBQ3FlPQgn4SPO+vQp2nDrJrPZ0nSspRlAcWBsb9LFSNwRqD5d55zxXDlGBP9w1/5A2b5j5wHN9cepuAJduIeTWGyakwb1KSaRlJefv2l1UsARsQL9jbY+f8AMOmt/wDEjG/CEZ0IOxJ76WnpXVnIrAXsQhHXNmuPUC08phdHAbvr6T1NWnVTDVwoV0DKSNQ4GVtVIuGAD3NwLb3nPr+NzP1wsNiDSJQb02YWPKE3Qnva09b4N+IkcZS2QjTXYEAc+onj/FaNSsKVRFY1HpDOFGrZXdC9vNdT0t3ne/Bn4LruPzKrClSvcZgMzbfHc/pXQb7+Wprn6dJ8UzvVZ2bONg1wQQOhAAmNDc5V1tv/AAJ9KpeH4HDgZcj1Gsilm/MLuxsAEuR3JsNBfrPL/jrxilSqmjRppTcoM9VEUOoc3Ciw3IH6twCbR56/IPN9ebNYFrAgBf8As36fle/oYeJQ2+/u8weG4Ylr7jgjbv5cC2+pnXqJcjpNyfrHVyZGWjh+2p3vuO0JMCb9PvedTD0RudjNv5FlF7AdeLdzxNOdYPCPBBXo10A+Oxt1IIGX3II9Z6XH+DhQt/icsSL/AKQQDkJHYAntvqRA8IwtZFJoqDUqEfGbZEpKdWPBZjcAdr8TZ4/ifjyByqXAeoB+jN/YOCbW14Dag3nO9e41zry7+K4bC1GBOeoAwFrm7kGwY9SdOTrPNYTw7EV3/OqKVQnOxe6K2t7H/b23toB09NU8UwNAFKQdr6l1VSxN7m5c3/ec/wAU/EFFlAC1X7O4UeRCgn/tHda+PP8AjFRbCmn6QSxNgMztu1hoo6DgTkVNBz5dZsxuMLtfKFHCgWUD9z3OpmF2vLDLnwggneCQY0xopWFz7fzNQWsskcyAxZFpIMkuSKUBGpFrHU4I1TpCw28pxzBoPZhH9Zaqw0JmdBHYqoLW94lGJ0Gncx/RPjRicNcZhvb3H8zCs3m2l3J9bD2mByAxtteFa5MY7R1M+kygzRThPqrp4XEsCtjZh+k7A/7G7Hg8HzM6HjtRalJKi731HIa2VwRxayadbzgKbczS2IYqUOt7e42Pt9BJmxkXe0bU2hKgkZdZHQ0MSyG+hU6MDqpHRh0+k9lhPw1Sroj0XILC+W4I0/WoNv1DextpteeRRAf4nQ8MxFTD1g1E2IAYqdA9iSQeONJm7+HXpPBPBsMHP9QzsyOVyIVVbrcG5/WQd9hpafSKGHpqt6apZheytmuLAG+uuwHpOZ+HvEk1qCylzma3yBPNhYekX+NKlJ0DrpWTWm6mxuNcrEbg/Kc7t+r/AF7mM2IWjhgzkKEVbLsWKhiwQXGgzNlt/dpfQG/BxH4k/NDNVbQ7IALC2wF9vP8AxOB+JcfUqUUqOfhLNlPWxtvybk//AJ7zzP8AVmdOeZ9rpXtH8e/LsygXW6pbYFltpfkC+vfvPO+MuHxLPmurJSN9zcUkUqe95xsTii2nSDSc73mus/A9X4XVCBlVbqMuY/6nO/tr9772qDjaZfCFvQBPJJHkPhufaGKqC3xDtqNfWMYs2ujhnJIHr7C/35zv+CUc7oovrfi2m5t6AzzOGqDe4PF733nqfBMdTw4ao99FyqBa5J3NzYDbc9ZdeTXO/Xd8R8PVTmpN+U+7EaI23602YcDnQDgzwH4hxVSoiKqgImYFUOYZxdmdrbtbrtrbS8Z4z4m+J0VkU3Pwowud73J1Y7CcPFVVDAkroGA7XAtY9c2T0vOc5ybresuMwpKCqLXBy1B0JF1cdmAa/dSedOVUPH33nQ/rwC5zE5lK2v8ArDGz5u1hp3IPETiaSqMt7tu/ReQgPJ5Y+Q4M1/E5eW8FkjnNtzYRLOt+ZGJh1W92Og46mFWfNtFMRpLJLRlVgRJUXS8MJLaMDLJLl2g2pYxYpTC/MkMaQ2kSYSNcQwsh8Nw2GzAk7D6xq01PEbT0ULAE3mM/RNhlUXGk5Z1JN5rxVZiMptodbc9JmUTPVn41JZ9BaErwysBhAtKPx1min85ipta02UrcRZpyrGql4o1QgufTrMLYx/7TYdIapzrq1sO1sy/qX5joRM+I8RDKrAWbI6n1sAR/2nKdixuSbwdRAznHdwHj7ooGbadHAVK+PqikjFU/vqHZF5Pc72HM8tQwxdXI/sANuTO34NVRQCmZHH9yuVJ8/wC0+RFoVrP16z8aeFJSpIqMQi/CKZOZb8Ojb36qepI3N/nz4Q3sD9+np7z1mP8AFzUpsjkNfm1vW3BnmKOJKOGP9vxDzW9vnLm/hm4z4zCmkcrfqG46dvOCnwEEjcBh5MLxeJqlySdSbknqTuYzFV82UWAyqFHWw6mKMbHuUCBiEBJC+euvWLVieYtF0j0WSytOEqMpDKSD2/frPXeHY0Ouq/EN9L/PieTw+9p3cDWWiC76Ajbk68D3mp459eul4i9JKSZ92LEjS5sbAddrEdzPL4lzUOYk5QCLkkkrfS5O579oKqartWe9iSVB2/8ABFYirc24+sKJ54o2B00Pbe0Fqlh2ky+5hrQubn/AktYSGc3sT9ISUTfXQToMFHf1iHZTI6yZLHWMXUymQnYR9GnZY8+q0qpvBYQmGsCoZpM5ELLJtqfaBczm6fC5IzLeAykRZFTexvOgi31HM5gmmlUI7ciW41JLMdFDyYDm20uhVDjXRhv0PftFVtdjK3xjmZfSnTW994Fo8ppKRLzMdKSJHIm9MNcTJiaJUkzTBYW4loQDr7xSvaU7yGNNQHUHW23lM7LNVEZlgMkDGcQuNvWC8tHk3DKNQocy7/e8MMQbjS+ottKpJcQwSVVbfpvr1uYa6/55nO3/AI0F8xzddD+xmPEj4vv74jy1l9vraZ8SdR5SxzLRLsB1IHzhOt2PmflBpvlYN0IPsZoVbk+ekLcdOOZ1M/oUHbaE50ueYYUA/fEVVNz6wl2unfM55tv1uwWMFND8ILk6MRfKthtf1+U6GEwDVf8A5ap+En4U625bt2nNwGFLtpr1PAnpHqWUKBoBab9eHu/+Obj24Gw+9JzAus6VffUQKdEPqPKTM8jIg1v0BMWyseTOiKNriQ0QNyB56SUrNgMBnuzsQq8A6k9L8CMxGCRdRcet/rNlGoiplDrf/kIuuQRNyM7dcyoDbe/pHUDcX+7wXTgy6dQWy7dJT63sxgxLfEYl3t5w8S+sQi31g1PEHUyoTwYFaia1QEWOoiCsch0gKH+k101g1ky29f2mym4BuZixmIzvcbbD+ZHm+jwoUk36H56RFN7Htz5SgxsQOd4dKlyZNWugiXhokGieJopLbeTGnUV4l4/DBkJ5HP3xGo436TlVMUz5rnrYcRDmEQbQybyoNNuB0X1hvTBkpOFUDf8AnziqlU8afWFa5sl9ZqwFzbaLQxj9BCw1HM0fxS+tODoljtp9ZvqUgBbtNNKllHpM2KexhGuurrFVXTtcD5zHW/V7R9apxxcH2+/lMzHW8WdQRiPAUQisLDz3eb4MveNwiKXXNtcX8jEJaOFcLsJYuu71fXrqVBVGVRYQK7qguxAE42HxtR1AJyjbMTYW8tyfWb6VFF1zBz/qJB9ukXCwhkLm9sqcDk95oasiJc6AfenUzPiseiA3YMegN/fpPP4nEs5uTpwOB5ShnOtmK8WY6J8I/wC3vxOc7km5N/OVKM1jcmJmhJVI2JHlpAlRxNyY87NqPnCeqLXBnPhqYVTmIxvHAWEUIaniEFgTKhMIN5FsdYr81RzfymmwIsdjMVbDFddx1/mWCBeqW7CAIaJDFOGtKR5oUA8iIySWhosdKgJrdBbcThWhoI6MdYOAD8V5zS2txtKL38pWWSkZyIVMa3MIrLyyJ2WZqp18vrH0wR988Q1UHLb+0fM8/KEHwpKGjHkAE+rKP3nQ8FwjO9lFzf09ZWGTR78obDydCflc+k3/AIefKR5yplelxn4bZEz/AJiE5c2X4gSdsq2vmN/LmeKxz5vMaHg+s9h454hZl10yA327Eelh854rxHF52JUHubb95czw6xuYuQHW5l5+0QmaUTfiTN2jadYjp8pIpUPQ+xmpKVhfnrM9SsWgrVZdjLE0NUMQxmmk6uNRY9pT4bo3uIRbGUyxDNA9veD+WfsiaQDBh/lmXkAjqLAhii3+k+0fhK9mAOx099jNdR+nlLRbXNNBv9JkUcTe76TOzXhaeb6QdIT6ajY/ZEF4dI3UqfSDd+qJvAlXsYUWLMbkMNHgqJRkyNqSnXY9v4glLCWpjVF9IIh0i8omtBwYZoDkQw6wlJMmhm78kdIDUwOJYtZFlnWRlseR6QkGtj9+USEpDRY9aV4aUpmrSnp3Ugaf4/zYesTht/T6f+xuLJ22sNfM8fSaDgihJsQpHwE6Ei5BPutowUnPYg97HuCCCPYmPwT2IiXTQnpr7axVV8twPTyPMqo6GL8Uao2Um6p8Kdhf53/YTJWbSZ6WkOs2koWZVveLEfQG/pAdLExRRPURZMe20QVkkvBJl2ktFGYY/FNt5jw68zQHkKtoowiYt5mmITeATLsZGHMocABGo8AHpKETPD89wREhpAxEAyxkVQcxQMcjX0i2S0YtRzfWVeWraWg2knRDyA3gCGszqMAjkEWomlFiyv8ALvHU14MbRSaFpyTKaI/8MS9AdzOkKMJcL1iHGeleK/p56BsCJnfB6yWucAV3Fx1H8Qqa3V2zAAA2sNSbaD3tfoLmdGhhiSQdwB6g3/gy6eE1YW0v8yBf6fOFhlcSkhvqCb9tfadjFDOtM72RR82cD0DW9JoTBrexHkfv794+ngwCR2FvUm494Yr05K4frOK6nNbpPWPT4nExmGyuT3MWZWC0jxrDrKqJpccSbiYSn8JPeDXTmasGnwe8jU76SWue6Xi2w5m1xlBPSc92J3MlCzCRbyiJUide0mft7RYYxtNb9IjFBwf8wskGpqfKOpIeP8QJTCQoOZpKdoD0pYtZctoJmopFlJLShKIjckHLJUvLCAMPLIFlqKNOVaPl5YjRLGIJckyqdTmlJJIhuw4vN9JZJIitKICJf5UkkEYKMEUZJIsrfC3sQSrDYj6EcjtLo0Tb4gLkm9tt+JJJI38qEqSSQDK9LWc3H0rn0kkio5lWhppMl7Agy5IOvLXRp5V05jbSSRBGIpA3Hacp0sbGSSFMKZJWWSSREqRy07a8SpJIf5PI2M000tJJFk0pBKSSSRT0os05JJIP5cs05JJItklZZUkzUEiTLJJFP//Z"),
(8, "https://ddragon.leagueoflegends.com/cdn/img/champion/splash/Irelia_0.jpg"),
(9, "https://2.bp.blogspot.com/-NbAjs60b7QA/XTti-Kn09PI/AAAAAAAAJWw/BKDPQ7XSLXkNM97P4UZ95Q17MK8ZmqMvgCLcBGAs/w919/braum-lol-mafia-splash-art-uhdpaper.com-4K-309-wp.thumbnail.jpg"),
(10, "https://i.pinimg.com/736x/56/32/6d/56326dd70df72769f0d430676b1455b7.jpg"),
(11, "https://cdna.artstation.com/p/assets/images/images/025/740/814/large/sangsoo-jeong-covenleblanc.jpg?1586790559");

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

INSERT INTO categoria_evento VALUES
(10, 1),
(11, 2),
(11, 3),
(10 ,4),
(6, 5),
(1, 6),
(3, 7),
(9, 8),
(1, 9),
(2, 10);

INSERT INTO preferencia VALUES
(1, "camix.santana"),
(1, "clara.barriento"),
(1, "allan.fagner"),
(1, "barbarafavilla"),
(1, "adriano.fraga"),
(1, "japafkt"),
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
(7, "japafkt"),
(9, "japafkt"),
(9, "camix.santana"),
(10, "camix.santana"),
(10, "clara.barriento"),
(10, "allan.fagner"),
(10, "barbarafavilla"),
(10, "adriano.fraga"),
(10, "japafkt");

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







 