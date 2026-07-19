SELECT
    DATE(registration_date) AS reg_date,
    COUNT(*) AS total_registrations
FROM Registrations
GROUP BY DATE(registration_date)
ORDER BY reg_date;