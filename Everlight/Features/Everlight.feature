Feature: Orders screen

Scenario Outline: Add order on Orders screen
	Given the user is on home page
	When the user adds a new order with following data
	| MRN   | FirstName   | LastName   | AccessionNumber   | Organisation   | SiteId   | Modality   | StudyDateTime   |
	| <MRN> | <FirstName> | <LastName> | <AccessionNumber> | <Organisation> | <SiteId> | <Modality> | <StudyDateTime> |
	Then the order should be added with accession number '<AccessionNumber>'
	And delete the order

	Examples:
	| MRN  | FirstName | LastName | AccessionNumber | Organisation | SiteId    | Modality | StudyDateTime       |
	| 4567 | Test      | Auto     | 8742            | Lumus (LUM)  | Ingleburn | CT (CT)  | 06/08/2021 11:49 AM |
	
Scenario Outline: Order not added when data is missing
	Given the user is on home page
	When the user tries to add a new order with following data
	| MRN   | FirstName   | LastName   | AccessionNumber   | Organisation   | SiteId   | Modality   | StudyDateTime   |
	| <MRN> | <FirstName> | <LastName> | <AccessionNumber> | <Organisation> | <SiteId> | <Modality> | <StudyDateTime> |
	Then the order should not be added with error '<error>'

	Examples:
	| MRN  | FirstName | LastName | AccessionNumber | Organisation | SiteId    | Modality | StudyDateTime       | error                                     |
	|      | Test      | Auto     | 8742            | Lumus (LUM)  | Ingleburn | CT (CT)  | 06/08/2021 11:49 AM | MRN is required.                          |
	| 1234 |           | Auto     | 8742            | Lumus (LUM)  | Ingleburn | CT (CT)  | 06/08/2021 11:49 AM | First Name is required.                   |
	| 1234 | Test      |          | 8742            | Lumus (LUM)  | Ingleburn | CT (CT)  | 06/08/2021 11:49 AM | Last Name is required.                    |
	| 1234 | Test      | Auto     |                 | Lumus (LUM)  | Ingleburn | CT (CT)  | 06/08/2021 11:49 AM | Accession Number is required.             |
	| 1234 | Test      | Auto     | 8742            |              | Ingleburn | CT (CT)  | 06/08/2021 11:49 AM | Organisation is required.                 |
	| 1234 | Test      | Auto     | 8742            | Lumus (LUM)  |           | CT (CT)  | 06/08/2021 11:49 AM | Site is required.                         |
	| 1234 | Test      | Auto     | 8742            | Lumus (LUM)  | Ingleburn |          | 06/08/2021 11:49 AM | Modality: The Modality field is required. |
	| 1234 | Test      | Auto     | 8742            | Lumus (LUM)  | Ingleburn | CT (CT)  |                     | Study DateTime is required.               |


