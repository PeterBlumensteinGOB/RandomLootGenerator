-- phpMyAdmin SQL Dump
-- version 4.8.5
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Erstellungszeit: 02. Mrz 2019 um 15:16
-- Server-Version: 10.1.38-MariaDB
-- PHP-Version: 7.3.2

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Datenbank: `randomloot`
--

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `lootitem`
--

CREATE TABLE `lootitem` (
  `ItemID` int(11) NOT NULL,
  `itemName` varchar(50) COLLATE utf8_german2_ci DEFAULT NULL,
  `ItemValue` int(10) UNSIGNED DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_german2_ci;

--
-- Daten für Tabelle `lootitem`
--

INSERT INTO `lootitem` (`ItemID`, `itemName`, `ItemValue`) VALUES
(1, 'Goldmünze', 10),
(4, 'Dolch', 50);

--
-- Indizes der exportierten Tabellen
--

--
-- Indizes für die Tabelle `lootitem`
--
ALTER TABLE `lootitem`
  ADD PRIMARY KEY (`ItemID`);

--
-- AUTO_INCREMENT für exportierte Tabellen
--

--
-- AUTO_INCREMENT für Tabelle `lootitem`
--
ALTER TABLE `lootitem`
  MODIFY `ItemID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
