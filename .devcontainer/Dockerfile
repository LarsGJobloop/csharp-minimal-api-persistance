FROM mcr.microsoft.com/devcontainers/dotnet:0-7.0

# Install extra packages
# See here for details https://github.com/devcontainers/images/blob/main/docs/TIPS.md
RUN apt-get update \
    && export DEBIAN_FRONTEND=noninteractive \
    && apt-get -y install --no-install-recommends \
# Add extra packages here 
    sqlite3 \
# End of package list
    && apt-get autoremove -y \
    && apt-get clean -y \
    && rm -rf /var/lib/apt/lists/*