SELECT writing_supply.supply_id, utensil_type, drawer_id, quantity
FROM writing_supply
LEFT JOIN pencil_drawer ON writing_supply.supply_id = pencil_drawer.supply_id
WHERE refill = true

UNION

SELECT writing_supply.supply_id, utensil_type, drawer_id, quantity
FROM writing_supply
RIGHT JOIN pen_drawer ON writing_supply.supply_id = pen_drawer.supply_id
WHERE refill = true
ORDER BY supply_id;