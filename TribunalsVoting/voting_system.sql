-- phpMyAdmin SQL Dump
-- version 4.9.0.1
-- https://www.phpmyadmin.net/
--
-- Host: localhost
-- Generation Time: Jul 11, 2019 at 03:44 AM
-- Server version: 10.3.16-MariaDB
-- PHP Version: 7.3.6

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;


Create database voting_system;--
-- Database: `voting_system`
--

-- --------------------------------------------------------

--
-- Table structure for table `tbl_admin`
--

CREATE TABLE `tbl_admin` (
  `Admin_ID` int(30) NOT NULL,
  `Username` varchar(50) DEFAULT NULL,
  `Password` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbl_admin`
--

INSERT INTO `tbl_admin` (`Admin_ID`, `Username`, `Password`) VALUES
(2, 'carl', 'dGl0ZQ=='),
(3, 'qwe', 'cXdl');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_candidates`
--

CREATE TABLE `tbl_candidates` (
  `Candidate_id` int(30) NOT NULL,
  `Candidate_Name` varchar(50) DEFAULT NULL,
  `Candidate_Nickname` varchar(50) DEFAULT NULL,
  `Candidate_Position` varchar(50) DEFAULT NULL,
  `Candidate_Party` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `tbl_candidate_achievement`
--

CREATE TABLE `tbl_candidate_achievement` (
  `Achievement_ID` int(30) NOT NULL,
  `Achievement_title` varchar(50) DEFAULT NULL,
  `Candidate_ID` int(30) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `tbl_candidate_platform`
--

CREATE TABLE `tbl_candidate_platform` (
  `Platform_ID` int(30) NOT NULL,
  `platform` varchar(50) DEFAULT NULL,
  `Candidate_ID` int(30) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `tbl_students`
--

CREATE TABLE `tbl_students` (
  `tbl_id` int(11) NOT NULL,
  `student_number` varchar(100) NOT NULL,
  `program` varchar(100) NOT NULL,
  `hasVoted` tinyint(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `tbl_votes`
--

CREATE TABLE `tbl_votes` (
  `Vote_ID` int(30) NOT NULL,
  `Candidate_ID` int(30) DEFAULT NULL,
  `Number_Of_Votes` int(30) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `tbl_admin`
--
ALTER TABLE `tbl_admin`
  ADD PRIMARY KEY (`Admin_ID`);

--
-- Indexes for table `tbl_candidates`
--
ALTER TABLE `tbl_candidates`
  ADD PRIMARY KEY (`Candidate_id`);

--
-- Indexes for table `tbl_candidate_achievement`
--
ALTER TABLE `tbl_candidate_achievement`
  ADD PRIMARY KEY (`Achievement_ID`),
  ADD KEY `Candidate_ID` (`Candidate_ID`);

--
-- Indexes for table `tbl_candidate_platform`
--
ALTER TABLE `tbl_candidate_platform`
  ADD PRIMARY KEY (`Platform_ID`),
  ADD KEY `Candidate_ID` (`Candidate_ID`);

--
-- Indexes for table `tbl_students`
--
ALTER TABLE `tbl_students`
  ADD PRIMARY KEY (`tbl_id`);

--
-- Indexes for table `tbl_votes`
--
ALTER TABLE `tbl_votes`
  ADD PRIMARY KEY (`Vote_ID`),
  ADD KEY `Candidate_ID` (`Candidate_ID`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `tbl_admin`
--
ALTER TABLE `tbl_admin`
  MODIFY `Admin_ID` int(30) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `tbl_candidates`
--
ALTER TABLE `tbl_candidates`
  MODIFY `Candidate_id` int(30) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `tbl_candidate_achievement`
--
ALTER TABLE `tbl_candidate_achievement`
  MODIFY `Achievement_ID` int(30) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `tbl_candidate_platform`
--
ALTER TABLE `tbl_candidate_platform`
  MODIFY `Platform_ID` int(30) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `tbl_students`
--
ALTER TABLE `tbl_students`
  MODIFY `tbl_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `tbl_votes`
--
ALTER TABLE `tbl_votes`
  MODIFY `Vote_ID` int(30) NOT NULL AUTO_INCREMENT;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `tbl_candidate_achievement`
--
ALTER TABLE `tbl_candidate_achievement`
  ADD CONSTRAINT `tbl_candidate_achievement_ibfk_1` FOREIGN KEY (`Candidate_ID`) REFERENCES `tbl_candidates` (`Candidate_id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `tbl_candidate_platform`
--
ALTER TABLE `tbl_candidate_platform`
  ADD CONSTRAINT `tbl_candidate_platform_ibfk_1` FOREIGN KEY (`Candidate_ID`) REFERENCES `tbl_candidates` (`Candidate_id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `tbl_votes`
--
ALTER TABLE `tbl_votes`
  ADD CONSTRAINT `tbl_votes_ibfk_1` FOREIGN KEY (`Candidate_ID`) REFERENCES `tbl_candidates` (`Candidate_id`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
