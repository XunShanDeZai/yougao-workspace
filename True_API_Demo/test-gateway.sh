#!/bin/bash

GATEWAY_URL="https://localhost:7071"
API_KEY="secret-key-123"

echo "=== Test 1: Without API Key (should get 401) ==="
curl -k -s -o /dev/null -w "%{http_code}\n" "$GATEWAY_URL/api/orders"

echo ""

echo "=== Test 2: With correct API Key ==="
curl -k -s -H "X-API-Key: $API_KEY" "$GATEWAY_URL/api/orders"

echo ""

echo "=== Test 3: Get single order ==="
curl -k -s -H "X-API-Key: $API_KEY" "$GATEWAY_URL/api/orders/5"

echo ""

echo "=== Test 4: Get users ==="
curl -k -s -H "X-API-Key: $API_KEY" "$GATEWAY_URL/api/users"

# 等待用户按键
echo ""
read -p "Press any key to exit..." -n1