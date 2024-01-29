Feature: Orders API

Scenario Outline: Add order using Orders API
	Given the user adds a new order using API with following data
	| patientMRN   | patientFirstName   | patientLastName   | AccessionNumber   | OrgCode   | SiteId   | Modality   | StudyDateTime   |
	| <patientMRN> | <patientFirstName> | <patientLastName> | <AccessionNumber> | <OrgCode> | <SiteId> | <Modality> | <StudyDateTime> |
	Then the order should be added with status code '201'
	And verify the order exists using API
	And delete the order using API

	Examples:
	| patientMRN | patientFirstName | patientLastName | AccessionNumber | OrgCode | SiteId | Modality | StudyDateTime    |
	| 4567       | Test             | Auto            | 8742            | USC     | 301    | CT       | 2002-11-11T12:12 |

Scenario Outline: Order not added using Orders API
	Given the user adds a new order using API with following data
	| patientMRN   | patientFirstName   | patientLastName   | AccessionNumber   | OrgCode   | SiteId   | Modality   | StudyDateTime   |
	| <patientMRN> | <patientFirstName> | <patientLastName> | <AccessionNumber> | <OrgCode> | <SiteId> | <Modality> | <StudyDateTime> |
	Then the order should not be added with API error '<error>'
	Examples: 
	| patientMRN | patientFirstName | patientLastName | AccessionNumber | OrgCode | SiteId | Modality | StudyDateTime    | error       |
	|            | Test             | Auto            | 8742            | USC     | 301    | CT       | 2002-11-11T12:12 | Bad Request |
	| 4567       |                  | Auto            | 8742            | USC     | 301    | CT       | 2002-11-11T12:12 | Bad Request |
	| 4567       | Test             |                 | 8742            | USC     | 301    | CT       | 2002-11-11T12:12 | Bad Request |


