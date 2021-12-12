# Marketman

תרגיל בית: מערכת "ידוענים"
צד שרת כתוב ב core5.
צד קלינט כתוב ב Angular (יש צורך להתקין NodeJS).
•	שליפת נתונים האתר https://www.imdb.com/list/ls052283250/ מבוצעת באמצעות רכיב WebClient() .
•	עבודה עם ה html מבוצעת באמצעות רכיב HtmlAgilityPack   nugget.
•	השלמת נתוני מגדר הסלבס מבוצעת באמצעות פנייה לשרות ב azure face detection באמצעות שליחת תמונת הסלבס קבלת מאפייני התמונה שכוללים מגדר.
•	טיפול ב exception מבוצע ברמה הכללית בMiddleware באמצעות ExceptionMiddlewareExtensions והודעת שגיאה מסודרת נשלחת ל client.
•	ה solution מחולק לארבעה פרויקטים:
1.	Model מחזיר את מבני הנתונים שמייצגים את ה json השונים.
2.	Logic מחזיק את הclass שמבצעים את הפניות, השמירה והלוגיקה הנדרשת.
3.	Marketman Rest API לבחינת הלוגיקה תוך שימוש ב swagger.
4.	MarketmanWeb ה client שכתוב ב angular ומציג את רשימת הסלבס עם כל הלוגיקה הנדרשת (מחיקה וטעינה מחדש).
MarketmanWeb הוא הפרויקט שיש להריץ.
בהצלחה.

