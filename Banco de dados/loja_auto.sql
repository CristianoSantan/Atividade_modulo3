-- drop schema loja_auto_cris;
DROP DATABASE IF EXISTS loja_auto_cris;

-- CREATE schema loja_auto_cris;
CREATE DATABASE IF NOT EXISTS loja_auto_cris;

USE loja_auto_cris;

-- `clientes` --------------------------------------------------------
CREATE TABLE `clientes` (
  `id_cliente` int AUTO_INCREMENT PRIMARY KEY,
  `CPF` varchar(30) NOT NULL,
  `nome` varchar(30) NOT NULL,
  `endereco` varchar(30) NOT NULL,
  `bairro` varchar(30) NOT NULL,
  `cidade` varchar(30) NOT NULL,
  `UF` varchar(20) NOT NULL,
  `CEP` varchar(20) NOT NULL,
  `cliente_desde` datetime DEFAULT NOW()
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- `veiculos` --------------------------------------------------------
CREATE TABLE `veiculos` (
  `id_veiculo` int AUTO_INCREMENT PRIMARY KEY,
  `modelo` varchar(30) NOT NULL,
  `marca` varchar(30) NOT NULL,
  `ano` varchar(30) NOT NULL,
  `cor` varchar(30) NOT NULL,
  `data_cadastro` datetime DEFAULT NOW()
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- `vendedores` --------------------------------------------------------
CREATE TABLE `vendedores` (
  `id_vendedor` int AUTO_INCREMENT PRIMARY KEY,
  `cpf` varchar(30) NOT NULL,
  `nome` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- `venda` --------------------------------------------------------
CREATE TABLE `venda` (
  `id_venda` int AUTO_INCREMENT PRIMARY KEY,
  `id_veiculo` int(11) NOT NULL,
  `id_cliente` int(11) NOT NULL,
  `id_vendedor` int(11) NOT NULL,
  `data_venda` datetime DEFAULT NOW()
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

ALTER TABLE `venda`
  ADD KEY `fk_id_veiculo` (`id_veiculo`),
  ADD KEY `fk_id_cliente` (`id_cliente`),
  ADD KEY `fk_id_vendedor` (`id_vendedor`);

ALTER TABLE `venda`
  ADD CONSTRAINT `fk_id_cliente` FOREIGN KEY (`id_cliente`) REFERENCES `clientes` (`id_cliente`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_id_veiculo` FOREIGN KEY (`id_veiculo`) REFERENCES `veiculos` (`id_veiculo`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_id_vendedor` FOREIGN KEY (`id_vendedor`) REFERENCES `vendedores` (`id_vendedor`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;
