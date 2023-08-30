# Application Registration Manifest AppRoles

## Install the Docker Kubernetes UI

```
	"appRoles": [
		{
			"allowedMemberTypes": [
				"User",
				"Application"
			],
			"description": "Extra Role",
			"displayName": "Extra",
			"id": "181a0c75-31f1-41ee-b7f1-2595dcabc1e4",
			"isEnabled": true,
			"lang": null,
			"origin": "Application",
			"value": "Extra"
		},
		{
			"allowedMemberTypes": [
				"User"
			],
			"description": "Role 1",
			"displayName": "Role1",
			"id": "3c37acb3-f9c1-487e-9407-eb49a686dbbb",
			"isEnabled": true,
			"lang": null,
			"origin": "Application",
			"value": "Role1"
		},
		{
			"allowedMemberTypes": [
				"User"
			],
			"description": "Role 2",
			"displayName": "Role2",
			"id": "240f7e8b-afc3-4f15-b6eb-ea7c5a1f6d2d",
			"isEnabled": true,
			"lang": null,
			"origin": "Application",
			"value": "Role2"
		},
		{
			"allowedMemberTypes": [
				"User",
				"Application"
			],
			"description": "Admin Role",
			"displayName": "Admin",
			"id": "4a4b5496-c817-4040-97bd-bacc5c098fef",
			"isEnabled": true,
			"lang": null,
			"origin": "Application",
			"value": "Admin"
		}
	],
	"oauth2AllowUrlPathMatching": false,
	"createdDateTime": "2023-08-28T16:08:59Z",
	"description": null,
	"certification": null,
	"disabledByMicrosoftStatus": null,
	"groupMembershipClaims": null,
	"identifierUris": [],
	"informationalUrls": {
		"termsOfService": null,
		"support": null,
		"privacy": null,
		"marketing": null
	},
	"keyCredentials": [],
	"knownClientApplications": [],
	"logoUrl": null,
	"logoutUrl": null,
	"name": "ApiConnectorDemo",
	"notes": null,
	"oauth2AllowIdTokenImplicitFlow": true,
	"oauth2AllowImplicitFlow": true,
	"oauth2Permissions": [],
	"oauth2RequirePostResponse": false,
	"optionalClaims": null,
	"orgRestrictions": [],
	"parentalControlSettings": {
		"countriesBlockedForMinors": [],
		"legalAgeGroupRule": "Allow"
	},
	"passwordCredentials": [
		{
			"customKeyIdentifier": null,
			"endDate": "2024-02-25T18:39:29.76Z",
			"keyId": "bbb27b8e-3bc8-4b99-99fe-940d4d5906e8",
			"startDate": "2023-08-29T17:39:29.76Z",
			"value": null,
			"createdOn": "2023-08-29T17:39:37.4476949Z",
			"hint": "87G",
			"displayName": "secret"
		}
	],
## Create a Service Account

Creating a Service Account with the name `admin-user` in namespace `kubernetes-dashboard` first.

dockerui-user-account.yaml
```yaml
apiVersion: v1
kind: ServiceAccount
metadata:
  name: admin-user
  namespace: kubernetes-dashboard
```

```
kubectl apply -f dockerui-user-account.yaml
```


