Feature: Orders screen

Scenario Outline: Add order on Orders screen
	Given the user is on home page
	When the user adds a new order with following data
	| MRN   | FirstName   | LastName   | AccessionNumber   | Organisation   | SiteId   | Modality   | StudyDateTime   |
	| <MRN> | <FirstName> | <LastName> | <AccessionNumber> | <Organisation> | <SiteId> | <Modality> | <StudyDateTime> |
	Then the order should be added with accession number '<AccessionNumber>'
	And delete the order with accession number '<AccessionNumber>'

	Examples:
	| MRN  | FirstName | LastName | AccessionNumber | Organisation                | SiteId    | Modality  | StudyDateTime       |
	| 4567 | Jacky     | John     | 8742            | Lumus (LUM)                 | Ingleburn | CT (CT)   | 06/08/2023 11:49 AM |
	| 4568 | David     | Henry    | 8743            | Care UK (CUK)               | Lincoln   | Xray (XR) | 07/09/2023 11:59 PM |
	| 4569 | Daniel    | Kane     | 8744            | The Ultrasound Clinic (USC) | Clinic    | MRI (MR)  | 27/11/2022 12:00 PM |

Scenario Outline: Order with duplicate accession number cannot be added on Orders screen
	Given the user is on home page
	When the user adds a new order with following data
	| MRN  | FirstName | LastName | AccessionNumber    | Organisation | SiteId    | Modality | StudyDateTime       |
	| <MRN1> | Jacky     | John     | <AccessionNumber> | Lumus (LUM)  | Ingleburn | CT (CT)  | 11/10/2022 12:02 AM |
	When the user adds a new order with following data
	| MRN  | FirstName | LastName | AccessionNumber    | Organisation  | SiteId  | Modality  | StudyDateTime       |
	| <MRN2> | David     | Henry    | <AccessionNumber> | Care UK (CUK) | Lincoln | Xray (XR) | 31/05/2022 11:59 AM |
	Then the order should not be added with error '<error>'
	And delete the order with accession number '<AccessionNumber>'

	Examples:
	| AccessionNumber | MRN1 | MRN2 | error                                         |
	| 5555            | 6324 | 6325 | An order already exists with accession number |

Scenario Outline: Verify orders are listed according to study datetime on Orders screen
	Given the user is on home page
	When the user adds a new order with following data
	| MRN  | FirstName | LastName | AccessionNumber    | Organisation | SiteId    | Modality | StudyDateTime    |
	| 5269 | Jacky     | John     | <AccessionNumber1> | Lumus (LUM)  | Ingleburn | CT (CT)  | <StudyDateTime1> |
	When the user adds a new order with following data
	| MRN  | FirstName | LastName | AccessionNumber    | Organisation  | SiteId  | Modality  | StudyDateTime    |
	| 5269 | David     | Henry    | <AccessionNumber2> | Care UK (CUK) | Lincoln | Xray (XR) | <StudyDateTime2> |
	Then the order should be listed in ascending order of study datetime '<StudyDateTime1>', '<StudyDateTime2>'
	And delete the order with accession number '<AccessionNumber1>'
	And delete the order with accession number '<AccessionNumber2>'

	Examples:
	| AccessionNumber1 | StudyDateTime1      | AccessionNumber2 | StudyDateTime2      |
	| 8756             | 06/08/2023 11:49 AM | 8757             | 07/09/2023 11:59 PM |
	| 8756             | 14/06/2023 09:25 AM | 8757             | 09/06/2023 08:25 AM |
	| 8756             | 13/12/2023 11:49 PM | 8757             | 13/12/2023 11:49 AM |

Scenario Outline: Order not added when data is missing
	Given the user is on home page
	When the user tries to add a new order with following data
	| MRN   | FirstName   | LastName   | AccessionNumber   | Organisation   | SiteId   | Modality   | StudyDateTime   |
	| <MRN> | <FirstName> | <LastName> | <AccessionNumber> | <Organisation> | <SiteId> | <Modality> | <StudyDateTime> |
	Then the order should not be added with error '<error>'

	Examples:
	| MRN  | FirstName | LastName | AccessionNumber | Organisation | SiteId    | Modality | StudyDateTime       | error                                     |
	| 7777 | Test      | Auto     | 8742            | Lumus (LUM)  | Ingleburn | CT (CT)  | 31/06/2021 10:30 AM | Study DateTime is required.               |
	| 7777 | Test      | Auto     | 8742            | Lumus (LUM)  | Ingleburn | CT (CT)  | 29/02/2023 02:15 AM | Study DateTime is required.               |
	| 8888 | Test      | Auto     | 8742            | Lumus (LUM)  | Ingleburn | CT (CT)  | 25/12/2024 06:10 PM | StudyDateTime cannot be in the future     |
	|      | Test      | Auto     | 8742            | Lumus (LUM)  | Ingleburn | CT (CT)  | 06/08/2021 11:49 AM | MRN is required.                          |
	| 1234 |           | Auto     | 8742            | Lumus (LUM)  | Ingleburn | CT (CT)  | 06/08/2021 11:49 AM | First Name is required.                   |
	| 1234 | Test      |          | 8742            | Lumus (LUM)  | Ingleburn | CT (CT)  | 06/08/2021 11:49 AM | Last Name is required.                    |
	| 1234 | Test      | Auto     |                 | Lumus (LUM)  | Ingleburn | CT (CT)  | 06/08/2021 11:49 AM | Accession Number is required.             |
	| 1234 | Test      | Auto     | 8742            |              | Ingleburn | CT (CT)  | 06/08/2021 11:49 AM | Organisation is required.                 |
	| 1234 | Test      | Auto     | 8742            | Lumus (LUM)  |           | CT (CT)  | 06/08/2021 11:49 AM | Site is required.                         |
	| 1234 | Test      | Auto     | 8742            | Lumus (LUM)  | Ingleburn |          | 06/08/2021 11:49 AM | Modality: The Modality field is required. |
	| 1234 | Test      | Auto     | 8742            | Lumus (LUM)  | Ingleburn | CT (CT)  |                     | Study DateTime is required.               |


