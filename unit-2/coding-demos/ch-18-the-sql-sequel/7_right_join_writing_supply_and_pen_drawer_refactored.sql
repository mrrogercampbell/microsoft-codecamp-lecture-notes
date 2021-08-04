SELECT writing_supply.supply_id, utensil_type, drawer_id, color
FROM writing_supply
RIGHT JOIN pen_drawer ON writing_supply.supply_id = pen_drawer.supply_id
WHERE refill = true;