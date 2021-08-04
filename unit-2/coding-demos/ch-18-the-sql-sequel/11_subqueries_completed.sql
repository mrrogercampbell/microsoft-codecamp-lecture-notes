SELECT drawer_id,
       color,
       quantity
FROM   pen_drawer
WHERE  supply_id = (SELECT MAX(supply_id)
                     FROM   writing_supply
                     WHERE  utensil_type = "pen")
       AND quantity >= 60; 