FROM nginx:alpine

# RUN addgroup -S appgroup && adduser -S appuser -G appgroup
# RUN chmod 0777 /usr/share/nginx/html


# Create app directory
WORKDIR /app

COPY . /usr/share/nginx/html

RUN chown -R nginx:nginx /app && chmod -R 755 /app && \
        chown -R nginx:nginx /var/cache/nginx && \
        chown -R nginx:nginx /var/log/nginx && \
        chown -R nginx:nginx /etc/nginx/conf.d

RUN touch /var/run/nginx.pid && \
        chown -R nginx:nginx /var/run/nginx.pid

USER nginx
EXPOSE 80
